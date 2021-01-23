    private CancellationTokenSource cts = null;
    private void btnHUp_MouseDown(object sender, MouseEventArgs e)
    {
      cts = new CancellationTokenSource();
      Task.Factory.StartNew(() => dothis(cts.Token));
    }
    private void btnHUp_MouseUp(object sender, MouseEventArgs e)
    {
       cts.Cancel();
    }
    public void dothis(CancellationToken token)
    {
      while (!token.IsCancellationRequested) 
      {
        intHour += intStep;       
        lblTimerHour.Invoke((Action)(
          () =>
          {
            lblTimerHour.Text = intHour.ToString("00");
          }));
        Thread.Sleep(1000);
      }     
    }
