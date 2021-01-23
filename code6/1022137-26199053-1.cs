    private void OpenWrite()
    {
        webClient.OpenWriteCompleted += webClient_OpenWriteCompleted;
        // I'm just using this as an example. It can be any data type, but I am using byte[] so I can write it to the stream later.
        byte[] data = new byte[] { 0, 1, 3, 4 }; 
        webClient.OpenWriteAsync(uri, method, data);
    }
    private void webClient_OpenWriteCompleted(object sender, OpenWriteCompletedEventArgs e)
    {
        // Now e.UserState contains whatever data you passed as the userToken.
        byte[] data = (byte[])e.UserState;
        // Now write this data to the stream
        e.Result.Write(data, 0, data.Length);
    }
