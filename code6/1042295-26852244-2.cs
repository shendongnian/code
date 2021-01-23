    using System;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                // input and output files
                string csv = @"c:\data\input.csv";
                string xls = @"c:\data\output.xlsx";
                // init the Appl obj
                Excel.Application xl = new Excel.Application();
                // get the worksheet
                Excel.Workbook wb = xl.Workbooks.Open(csv);
                Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets.get_Item(1);
                // select the used range
                Excel.Range used = ws.UsedRange;
                // autofit the columns
                used.EntireColumn.AutoFit();
           
                // save as xlsx
                wb.SaveAs(xls, 51);
                wb.Close();
                xl.Quit();
            }
        }
    }
