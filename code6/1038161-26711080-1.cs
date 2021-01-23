    Parallel.ForEach(
      devices,
      device => {
        if (device.PlatformType.ToUpperInvariant() == "IOS") {
          push.QueueNotification(
            new AppleNotification()
              .ForDeviceToken(device.DeviceToken)
              .WithAlert(message)
              .WithBadge(device.Badge)
          );
        }
      }
    );
    push.StopAllServices(true);
