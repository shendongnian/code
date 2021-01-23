    using System.Diagnostics;
    try
    {
          foreach (var p in Process.GetProcessesByName("EXCEL.EXE"))
              p.Kill();
    }
