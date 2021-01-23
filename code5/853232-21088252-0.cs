    Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
    
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlApp.Visible = true;
                xlWorkBook = xlApp.Workbooks.Open(@"C:\Users\knm\Documents\Book2.xlsx");
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Activate();
                
    
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
