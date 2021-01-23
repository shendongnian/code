    #if DEBUG
      connectionSettings.EnableDebugMode(details =>
      {
        Logger.Debug($"ES Request: {Encoding.UTF8.GetString(details.RequestBodyInBytes)}");
        Logger.Debug($"ES Response: {Encoding.UTF8.GetString(details.ResponseBodyInBytes)}");
      });
    #endif
