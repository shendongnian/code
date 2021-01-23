    public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
    {
        var deviceTokenString = deviceToken.ToString().Replace("<","").Replace(">", "").Replace(" ", "");
        var notificationService = Resolver.Resolve<IPushNotificationService>();
        var pushNotificationRegister = Resolver.Resolve<IPushNotificationRegister>();
                
        if (pushNotificationRegister.ShouldSendToken(deviceTokenString))
        {
            var uid = UIDevice.CurrentDevice.IdentifierForVendor.AsString();
            notificationService.AddPushToken(deviceTokenString, DeviceUtils.GetDeviceType(), uid);
        }
    }
