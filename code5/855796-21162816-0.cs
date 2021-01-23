    frmProgressAsync prog = new frmProgressAsync(true);
    TaskWithProgress t = new TaskWithProgress("Smoothing CP", true);
    t.Task = ShowMovingAveragesAsync(A, B, tension, t.Progress);
    await prog.RunAsync(t);
    private async Task ShowMovingAveragesAsync(TA A, TA B, TT tession, IProgress<string> progress)
    {
      progress.Report("Smoothing FG");
      await A.ShowMovingAverageAsync(tension, progress);
      progress.Report("Smoothing FG");
      await B.ShowMovingAverageAsync(tension, progress);
    }
    public virtual async Task RunAsync(TaskWithProgress task)
    {
      Show();
      TaskIsRunning();
      await task;
      Close();
    }
