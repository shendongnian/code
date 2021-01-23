    using System.Diagnostics;
    try
    {
    	Process [] proc Process.GetProcessesByName("EXCEL.EXE");
    	proc[0].Kill();
    }
