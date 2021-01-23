    public void dothis()
    {
      while (intHour < 23) 
      {
        intHour = intHour += intStep;       
        lblTimerHour.Invoke((Action)(
          () =>
          {
            lblTimerHour.Text = intHour.ToString("00");
          }));
      }     
    }
