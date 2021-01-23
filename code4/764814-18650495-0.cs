    using System.Linq;
    
    if (!System.Diagnostics.Process.GetProcesses().Any(p => p.ProcessName.Equals("conquer.exe", System.StringComparison.OrdinalIgnoreCase)))
    {
      Application.Exit();
    }
