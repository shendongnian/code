    private void updaterTimer_Tick(object sender, EventArgs e)
    {
        updaterTimer.Stop();
        Time.Content = "Time : " + DateTime.Now.ToLongTimeString();
        exist = saved_settings();
        if (exist)
        {
            settingForToday();
            checkSigningAvailable();
            setSigning(signingAvailable = getSigning());
        }
        else
        {
            ongoing.Content = "Event : No Event";
            sign_in.Content = "Sign-in Time : ";
            sign_out.Content = "Sign-out Time : ";
        }
        updaterTimer.Start();
    }
