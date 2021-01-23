    private CancellationTokenSource cts = new CancellationTokenSource();
    public void dothis()
    {
      CancellationToken token = cts.Token;
      while (!token.IsCancellationRequested)
      {
        // Continue doing work on the worker thread here.
      }
    }
    private void btnHUp_MouseUp(object sender, MouseEventArgs e)
    {
       cts.Cancel();
    }
