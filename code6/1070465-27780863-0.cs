    private void DoWork(string abc)
    {
      MyItem.Text = abc;
    }
    private async Task DoWorkWithDelayAsync(string abc, CancellationToken token)
    {
      try
      {
        await Task.Delay(TimeSpan.FromSeconds(2), token);
      }
      catch (OperationCanceledException)
      {
        // TODO: add a notification that the task did *not* run.
      }
      DoWork(abc);
    }
    private CancellationTokenSource cts;
    public bool OnTouch(MotionEvent e)
    {
      switch (e.Action)
      {
        case MotionEvent.Down:
          cts = new CancellationTokenSource();
          var _ = DoWorkWithDelayAsync("", cts.Token);
          break;
        case MotionEvent.Move:
        case MotionEvent.Up:
          if (cts != null)
            cts.Cancel();
          break;
      }
      return true;
    }
