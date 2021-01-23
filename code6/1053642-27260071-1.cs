    using System;
    using System.Runtime.InteropServices;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                // create app
                var excelApp = new Excel.Application();
                // open workbook
                var workbook = excelApp.Workbooks.Open(
                    @"C:\Users\Home\Documents\Book1.xlsx",
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                // open sheet
                var sheet = (Excel.Worksheet)workbook.Sheets[1];
                // create some variables
                var from = "Pete";
                var to = "Dave";
                // compare cell A1 [1,1] with 'from'
                if (string.Equals(sheet.Cells[1,1].Value, from))
                {
                    sheet.Cells[1, 1].Value = to;
                }
    
                // save the workbook
                workbook.Save();
                // close the workbook and release resources
                workbook.Close(true, workbook.Path);
                Marshal.ReleaseComObject(workbook);
                workbook = null;
            }
        }
    }
