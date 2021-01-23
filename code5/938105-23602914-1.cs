    static void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
    {
        if (e.Mode == Microsoft.Win32.PowerModes.StatusChange)
        {
            if (pw.BatteryLifeRemaining == 20)
            {
             //Do stuff here
            }
        }
    }
