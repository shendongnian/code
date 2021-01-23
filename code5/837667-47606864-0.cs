    System.Diagnostics.Process[] proc=System.Diagnostics.Process.GetProcessesByName("Excel");
    foreach (System.Diagnostics.Process p in proc)
    {
        if (!string.IsNullOrEmpty(p.ProcessName))
        {
            try
            {
                p.Kill();
            }
            catch { }
        }
    }
