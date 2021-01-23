    public void Close()
    {
        try
        {
            if (_workBook == null)
            {
                return;
            }
            _workBook.Save();
            _workBook.Close(false, FILENAME, null);
            Marshal.ReleaseComObject(_workBook);
            _excel.Quit();
            Marshal.ReleaseComObject(_excel);
            _workBook = null;
            _excel = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Logger("All done!");
        }
        catch (Exception e)
        {
            Logger("Error in cleanup: " + e.ToString());
        }
    }
