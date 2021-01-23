    public delegate void DoAsync();
    private void timer1_Tick(object sender, EventArgs e)
    {
       DoAsync async = new DoAsync(GetBatteryDetails);
       async.BeginInvoke(null, null);
    }
    public void GetBatteryDetails()
    {
       int i = 0;
       PowerStatus ps = SystemInformation.PowerStatus;
       if (ps.BatteryLifePercent <= 25)
       {
          if (this.InvokeRequired)
              this.Invoke(new Action(() => JARVIS.Speak("Warning, Battery level has dropped below 25%");      
          else
              JARVIS.Speak("Warning, Battery level has dropped below 25%");
       }
       i++;
    }
    
