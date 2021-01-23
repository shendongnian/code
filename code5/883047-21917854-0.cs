    public void KillProcess()
    {
        _workBook.Close();
        _workBooks.Close();
        _excelApp.Quit();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Marshal.FinalReleaseComObject(_workSheets);
        Marshal.FinalReleaseComObject(_workBook);
        Marshal.FinalReleaseComObject(_workBooks);
        Marshal.FinalReleaseComObject(_excelApp);
    }
