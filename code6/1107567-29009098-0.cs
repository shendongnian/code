    //get Id when workbook/xlApp are still visible
    private int getExcelFileProcessId(string excelFileName)
    {
      int procId = -1;
      var processes = from p in Process.GetProcessesByName("EXCEL")
                      select p;
      foreach(var process in processes)
      {
        if(process.MainWindowTitle == excelFileName + " - Excel")
        {
          procId = process.Id;
        }
      }
      return procId;
    }
    //helper method to kill zombie excel processes
    private void KillSpecificExcelFileProcess(int anId)
    {
      var processes = from p in Process.GetProcessesByName("EXCEL")
                      select p;
      foreach(var process in processes)
      {
        if(process.Id == anId)
        {
          process.Kill();
        }
      }
    }
