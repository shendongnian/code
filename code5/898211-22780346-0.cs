        Microsoft.Office.Interop.Excel.Worksheet activeSheet =
        (Microsoft.Office.Interop.Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
        
        Excel.Range firstColumn = activeSheet.UsedRange.Columns["A", System.Type.Missing];
       
        firstColumn.Select();
