    public async Task ExecuteCommand(string userId, string deviceId)
    {
      var link = await LinkProviderAsync.GetDeviceLinkAsync(deviceId, userId);
      var commandResponse = await link.CommandAsync(Commands.ConnectToDevice);
    }
