    using System.Diagnostics;
    Process[] ProcessList = Process.GetProcessesByName("Your Setup FileName");
    foreach (Process process in ProcessList)
    {
    	process.Kill();
    }
