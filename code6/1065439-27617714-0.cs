    private async void RequestFinished(object sender, OAuthEventArgs eventArgs)
    {
        if (eventArgs.IsError)
        {
            ErrorLogger.Log(eventArgs.ErrorMessage);
        }
        else
        {
            await TestLogger.Log(eventArgs.TestItem);
        }
    }
