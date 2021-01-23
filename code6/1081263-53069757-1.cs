    #if DEBUG
      connectionSettings.EnableDebugMode(details =>
      {
        Logger.Debug($"ES Request: {Encoding.UTF8.GetString(details.RequestBodyInBytes ?? new byte[0])}");
        Logger.Verbose($"ES Response: {Encoding.UTF8.GetString(details.ResponseBodyInBytes ?? new byte[0])}");
      });
    #endif
