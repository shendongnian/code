    private CancellationTokenSource cts = new CancellationTokenSource();
    private void btnHUp_MouseDown(object sender, MouseEventArgs e)
    {
      Task.Factory.StartNew(dothis);
    }
    public void dothis()
    {
      CancellationToken token = cts.Token;
      while (!token.IsCancellationRequested && intHour < 23) 
      {
        intHour = intHour += intStep;       
        lblTimerHour.Invoke((Action)(
          () =>
          {
            lblTimerHour.Text = intHour.ToString("00");
          }));
      }     
    }
    private void btnHUp_MouseUp(object sender, MouseEventArgs e)
    {
       cts.Cancel();
    }
