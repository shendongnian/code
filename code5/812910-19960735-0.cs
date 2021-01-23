     //using Microsoft.Office.Interop.Excel;
            Microsoft.Office.Interop.Excel.Application excelapp = new Microsoft.Office.Interop.Excel.Application();
           // excelapp.Visible = true;
            string filename_Path = @"D:\exmp1.xls";
            _Workbook workbook = (_Workbook)(excelapp.Workbooks.Open(filename_Path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing));
            
           
           
        excelapp .Cells .Columns .AutoFit ();
        workbook.Save();
       // workbook.Close();
        excelapp.Quit(); 
