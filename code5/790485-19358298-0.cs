    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication3
    { 
    class Program
    {
        static void Main(string[] args)
        {
            Application excel = new Application();
            Workbook wb1 = excel.Workbooks.Open("c:\\temp\\me.xlsx");
            Workbook wb2 = excel.Workbooks.Open("c:\\temp\\you.xlsx");
            Range src = wb1.Sheets["Sheet1"].Range("A1:B3");
            Range dest = wb2.Sheets["Sheet1"].Range("A10");
            src.Copy(dest);
            wb2.Save();
            wb1.Close();
            wb2.Close();
            excel.Quit();
        }
    }
    }
