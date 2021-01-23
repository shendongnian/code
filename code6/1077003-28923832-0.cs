    private enum ProcessDPIAwareness
    {
      ProcessDPIUnaware = 0,
      ProcessSystemDPIAware = 1,
      ProcessPerMonitorDPIAware = 2
    }
    [DllImport("shcore.dll")]
    private static extern int SetProcessDpiAwareness(ProcessDPIAwareness value);
    private static void SetDpiAwareness()
    {
      try
      {
        if (Environment.OSVersion.Version.Major >= 6)
        {
          SetProcessDpiAwareness(ProcessDPIAwareness.ProcessPerMonitorDPIAware);
        }
      }
      catch (EntryPointNotFoundException)//this exception occures if OS does not implement this API, just ignore it.
      {
      }
    }
