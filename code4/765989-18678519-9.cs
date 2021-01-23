    private Stopwatch ProcTimer = new Stopwatch();
    private TimeSpan MaxTime = TimeSpan.FromMinutes(5);
    private TimeSpan Remaining { get { return MaxTime - ProcTimer.Elapsed; } }
    private void RunfunctionA()
    {
        using (var proc = new System.Diagnostics.Process())
        {
            // initialization
            proc.Start();
            proc.WaitForExit((int)Remaining.TotalMilliseconds);
            if (proc.HasExited)
                ;// ...
            else
                proc.Kill();
        }
    }
