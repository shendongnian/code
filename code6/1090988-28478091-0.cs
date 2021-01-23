    public static Tuple<Task, CancellationTokenSource> Blink(this Label label)
    {
      var cts = new CancellationTokenSource();
      var task = BlinkAsync(label, cts.Token);
      return Tuple.Create(task, cts);
    }
    private static Task BlinkAsync(Label label, CancellationToken cancellationToken)
    {
      label.Visible = true;
      while (true)
      {
        label.Visible = !label.Visible;
        cancellationToken.ThrowIfCancellationRequested();
        await Task.Delay(600);
      }
    }
