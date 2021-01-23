    RegisterToReceiveMessages<string>(MessageTokens.SomeToken, OnMessageReceived);
    private void OnMessageReceived(object sender, NotificationEventArgs<string> e)
    {
        // Code to execute upon message reception.
    }
