    Parallel.ForEach(
      devices,
      () => new Push(),
      (device, _, push) => {
        if (device.PlatformType.ToUpperInvariant() == "IOS") {
          push.QueueNotification(
            new AppleNotification()
              .ForDeviceToken(device.DeviceToken)
              .WithAlert(message)
              .WithBadge(device.Badge)
          );
        }
        return push;
      },
      push.StopAllServices(true);
    );
