    public void KillChromeProcesses()
    {
      foreach (var proc in Process.GetProcessByName("chrome"))
      {
        proc.Kill();
      }
    }
