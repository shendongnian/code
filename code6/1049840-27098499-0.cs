    ManualResetEvent resetEvent;
    private void DispatchMail(MailMessage message, MessageTrackerObject trackInfo)
    {
        // other code here
    	resetEvent = new ManualResetEvent(false);
        mailClient.EnableSsl = GetStaticSetting(Constants.APPCONFIG_KEY_MAIL_SSL).ToLower() == "true";
        mailClient.SendCompleted += new SendCompletedEventHandler(MailClient_SendCompleted);
        mailClient.SendAsync(message, trackInfo);
    	resetEvent.WaitOne(TimeSpan.FromSeconds(5)); // waits for 5 seconds
        //mailClient.Send(message);
    }
    
    private void MailClient_SendCompleted(object sender, AsyncCompletedEventArgs e)
    {
        resetEvent.Set(); // removes the wait after successfully sending
        string error = "";
        MessageTrackerObject data = (MessageTrackerObject)e.UserState;
    	// other code here
    }
