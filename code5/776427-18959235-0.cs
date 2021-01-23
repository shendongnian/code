    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
      if (TimeTb.InvokeRequired)
      {
        TimeTb.Invoke((MethodInvoker)delegate
                    {
                      OnTimedEvent(source, e);
                    });
    
      }
    
      TimeTb.Text = e.SignalTime.ToString();
    }
