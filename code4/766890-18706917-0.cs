    Microsoft.Office.Interop.Excel.Workbook nativeWorkbook = Globals.ThisAddIn.Application.ActiveWorkbook;
    if (nativeWorkbook != null)
    {
        Microsoft.Office.Tools.Excel.Workbook vstoWorkbook = 
            Globals.Factory.GetVstoObject(nativeWorkbook);
    }
