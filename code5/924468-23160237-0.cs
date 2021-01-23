    RegisterToReceiveMessages<string>(MessageTokens.SomeToken, OnTokenReceived);
    private void OnTokenReceived(object sender, NotificationEventArgs<string> e)
    {
        // Code to execute upon message reception.
    }
