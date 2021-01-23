    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using Microsoft.Office.Interop.Excel;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string mySheet = @"E:\7.xlsx";
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;
                Workbook wb = excelApp.Workbooks.Open(mySheet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
     }
     }
