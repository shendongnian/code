    // start excel
    var before = Process.GetProcessesByName("Excel");
    _application = new Excel.Application();
    var after = Process.GetProcessesByName("Excel");
    
    _process = after.Where(p => !before.Any(x => x.Id == p.Id)).FirstOrDefault();
    // clean up
    _application.Quit();
    Marshal.FinalReleaseComObject(_application);
    _application = null;
    
    GC.Collect();
    GC.WaitForPendingFinalizers();
    if (_process != null && !_process.HasExited)
    {
        _process.Kill();
    }
