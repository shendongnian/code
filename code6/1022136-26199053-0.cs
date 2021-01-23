    private void OpenWrite()
    {
        webClient.OpenWriteCompleted += webClient_OpenWriteCompleted;
        int recordId = 1; // I'm just using this as an example. It can be anything.
        webClient.OpenWriteAsync(uri, method, recordId);
    }
    private void webClient_OpenWriteCompleted(object sender, OpenWriteCompletedEventArgs e)
    {
        // Now e.UserState contains whatever data you passed as the userToken.
        int recordId = (int)e.UserState;
    }
