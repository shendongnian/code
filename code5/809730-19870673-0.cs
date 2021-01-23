    using System;
    using System.Collections.Generic;
    using System.Text;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ExcelCutAndInsertColumn
    {
        class Program
        {
            static void Main(string[] args)
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWb = xlApp.Workbooks.Open(@"C:\stackoverflow.xlsx");
                Excel.Worksheet xlWs = (Excel.Worksheet)xlWb.Sheets[1]; // Sheet1
    
                xlApp.Visible = true;
    
                // cut column B and insert into A, shifting columns right
                Excel.Range copyRange = xlWs.Range["B:B"];
                Excel.Range insertRange = xlWs.Range["A:A"];
    
                insertRange.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, copyRange.Cut());
            }
        }
    }
