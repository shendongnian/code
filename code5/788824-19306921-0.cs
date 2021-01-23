    public async Task connectAsync(string token, string idInstalation, string lang)
    private async Task connectMeAsync()
    {
      await WebSocketClient.connectAsync(null, null, null);
      Frame.Navigate(typeof(MainContentPage));
    }
