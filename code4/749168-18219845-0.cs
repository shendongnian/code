    public delegate void DoAsync();
    private void button1_Click(object sender, EventArgs e)
    {
      //Call this method every 15 minutes instead of Button1_Click
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
    
