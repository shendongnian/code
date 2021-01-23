    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace MergeBooks
    {
        class Program
        {
            static void Main(string[] args)
            {
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook wb1 = exApp.Workbooks.Open(@"C:\wb1.xls");
                Excel.Workbook wb2 = exApp.Workbooks.Open(@"C:\wb2.xls");
                Excel.Worksheet worksheet1 = wb1.Worksheets[1];
                Excel.Worksheet worksheet2 = wb2.Worksheets[1];
                worksheet1.Copy(worksheet2);
                wb2.SaveAs(@"C:\wb3.xls");
    
                wb1.Close(false);
                wb2.Close(false);
                exApp.Quit();
    
            }
        }
    }
