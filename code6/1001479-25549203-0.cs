    using Microsoft.Office.Interop.Excel;
    using System;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                var filename = @"C:\temp\Book1.xlsx";
                var excel = new Microsoft.Office.Interop.Excel.Application();
    
                var wb = excel.Workbooks.Open(filename);
                Worksheet realtime = wb.Sheets["RealTime"];
    
                foreach (Range row in realtime.UsedRange.Rows)
                {
                    Console.WriteLine("{0}", row.Cells[1, 1].Value); // Column A
                    Console.WriteLine("{0}", row.Cells[1, 2].Value); // Column B
                    // etc ...
                }
    
                wb.Close(SaveChanges: false);
            }
        }
    }
