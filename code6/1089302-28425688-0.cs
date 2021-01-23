    using Excel = Microsoft.Office.Interop.Excel;
    var workbookFile = new FileInfo(reportFile);
    using (var excel = new ExcelPackage(workbookFile))
    {
        var wb = excel.Workbook;
        var ws = wb.GetCleanWorksheet("Report");
        ws.Select();
    
        // write data to sheet
        ws.Cells[1, 1].Value = "foo";
    
        excel.Save();
    }
    Excel.Application _Excel = null;
    Excel.Workbook WB = null;
    try
    {
    
        _Excel = new Microsoft.Office.Interop.Excel.Application();
        WB = _Excel.Workbooks.Open(reportFile);
        WB.Close(true);
    }
    catch (Exception ex)
    {
        WB.Close(false);
    }
    finally
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(WB);
        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(_Excel);
    }
