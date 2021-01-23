    using System;
    using System.Diagnostics;
    Process p = Process.GetCurrentProcess();
    PerformanceCounter parent = new PerformanceCounter("Process", "Creating Process ID", p.ProcessName);
    int ppid = (int)parent.NextValue();
    if (Process.GetProcessById(ppid).ProcessName == "powershell") {
      Console.WriteLine("running in PowerShell");
    } else {
      Console.WriteLine("not running in PowerShell");
    }
