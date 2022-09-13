using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleApp6
{
    internal class Proveedor : Item
    {
        public String ID;
        public String RUC;
        public String RazonSocial;
        public String Dirección;
        public String Ciudad;
        public String Telefóno;

        public Proveedor(Consola _consola, BaseDatos _objBD) : base(_consola, _objBD, "000", "Proveedor", "ID")
        {
        }

        public Proveedor(Consola _consola, BaseDatos _objBD, String _Codigo,
            String ID, String RUC, String RazonSocial, String Dirección, String Ciudad, String Telefóno)
            : base(_consola, _objBD, _Codigo, "Proveedor", "ID")
        {
            this.ID = ID;
            this.RUC = RUC;
            this.RazonSocial = RazonSocial;
            this.Dirección = Dirección;
            this.Ciudad = Ciudad;
            this.Telefóno = Telefóno
        }

        public override Item creatItem(Consola _consola, BaseDatos _objBD)
        {
            return new Proveedor(_consola, _objBD);
        }

        public override Item creatItem(Consola _consola, BaseDatos _objBD, DataRow _registro)
        {
            return new Proveedor(_consola, _objBD, _registro["ID"].ToString(), _registro["RUC"].ToString(), _registro["RazonSocial"].ToString(), _registro["Dirección"].ToString(), _registro["Ciudad"].ToString(), _registro["Telefóno"].ToString();
        }

        public override void mostrarMembreteTabla()
        {
            consola.Escribir(40, 2, ConsoleColor.Yellow, "LISTA DE PROVEEDORES");
            consola.Escribir(5, 5, ConsoleColor.Blue, "N°"); consola.Escribir(10, 5, ConsoleColor.Blue, "ID");
            consola.Escribir(30, 5, ConsoleColor.Blue, "RUC"); consola.Escribir(60, 5, ConsoleColor.Blue, "RazonSocial");
            consola.Escribir(70, 5, ConsoleColor.Blue, "Dirección"); consola.Escribir(80, 5, ConsoleColor.Blue, "Ciudad");
            consola.Marco(3, 4, 95, 15);
            consola.Escribir(90, 5, ConsoleColor.Blue, "Telefóno");
            consola.Marco(3, 4, 95, 15);
        }

        public override void mostrarInfoComoFila(int Num, int fila)
        {
            consola.Escribir(5, fila, ConsoleColor.White, Num.ToString());
            consola.Escribir(10, fila, ConsoleColor.White, ID);
            consola.Escribir(25, fila, ConsoleColor.White, RUC);
            consola.Escribir(55, fila, ConsoleColor.White, RazonSocial);
            consola.Escribir(70, fila, ConsoleColor.White, Dirección);
            consola.Escribir(80, fila, ConsoleColor.White, Ciudad);
            consola.Escribir(90, fila, ConsoleColor.White, Telefóno);
        }


        public override void mostrarInfo()
        {

            consola.Escribir(30, 2, ConsoleColor.Red, "INFORMACIÓN DEL PROVEEDOR");
            consola.Marco(10, 3, 65, 11);
            consola.Escribir(20, 5, ConsoleColor.Yellow, "ID: "); consola.Escribir(35, 5, ConsoleColor.White, ID);
            consola.Escribir(20, 6, ConsoleColor.Yellow, "RUC: "); consola.Escribir(35, 6, ConsoleColor.White, RUC);
            consola.Escribir(20, 7, ConsoleColor.Yellow, "RAZONSOCIAL: "); consola.Escribir(35, 7, ConsoleColor.White, RazonSocial);
            consola.Escribir(20, 8, ConsoleColor.Yellow, "DIRECCIÓN: "); consola.Escribir(35, 8, ConsoleColor.White, Dirección);
            consola.Escribir(20, 9, ConsoleColor.Yellow, "CIUDAD: "); consola.Escribir(35, 9, ConsoleColor.White, Ciudad);
            consola.Escribir(20, 10, ConsoleColor.Yellow, "TELEFÓNO:"); consola.Escribir(35, 10, ConsoleColor.White, Telefóno);
        }

        public override void leerInfo()
        {

            consola.Escribir(30, 2, ConsoleColor.Red, "NUEVO PROVEEDOR");
            consola.Marco(10, 3, 65, 11);
            consola.Escribir(20, 5, ConsoleColor.Yellow, "ID: ");
            consola.Escribir(20, 6, ConsoleColor.Yellow, "RUC: ");
            consola.Escribir(20, 7, ConsoleColor.Yellow, "RazonSocial: ");
            consola.Escribir(20, 8, ConsoleColor.Yellow, "Dirección: ");
            consola.Escribir(20, 9, ConsoleColor.Yellow, "Ciudad: ");
            consola.Escribir(20, 10, ConsoleColor.Yellow, "Telefóno: ");
            ID = consola.leerCadena(35, 5);
            RUC = consola.leerCadena(35, 6);
            RazonSocial = consola.leerCadena(35, 7);
            Dirección = consola.leerCadena(35, 8);
            Ciudad = consola.leerCadena(35, 9);
            Telefóno = consola.leerCadena(35, 10);
        }
        public override String getSQL(String TipoSQL, String CodigoABuscar = "")
        {
            String SQL = "";
            switch (TipoSQL)
            {
                case "Insert":
                    SQL = "Insert into TbProveedores (RUC, RazonSocial,Direccion,Ciudad,Telefono) values('"
                    + RUC + "','" + RazonSocial + "','" + Direccion + "','" + Ciudad + "','" + Telefono + "');";
                    break;
                case "Delete":
                    SQL = "Delete from TbProveedores where RUC='" + CodigoABuscar + "'";
                    break;
                case "Select":
                    if (CodigoABuscar != "")
                    {
                        SQL = "Select * from TbProveedores where RUC='" + CodigoABuscar + "'";
                    }
                    else
                    {
                        SQL = "Select * from TbProveedores order by RUC
                    }
                    break;
            }

            return SQL;
        }
    }
}
