    static public Task<Stream> OpenReadAsync(FtpClient ftpClient, string url)
    {
        return Task.Factory.FromAsync(
             (asyncCallback, state) =>
                 ftpClient.BeginOpenRead(url, asyncCallback, state),
             (asyncResult) =>
                 ftpClient.EndOpenRead((asyncResult));
    }
