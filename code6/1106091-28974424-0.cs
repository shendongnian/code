    if (UIDevice.CurrentDevice.SystemVersion [0] >= '8')
    {
        UIUserNotificationType types = UIUserNotificationType.Badge | UIUserNotificationType.Sound | UIUserNotificationType.Alert;
        UIUserNotificationSettings settings = UIUserNotificationSettings.GetSettingsForTypes (types, null);
        UIApplication.SharedApplication.RegisterUserNotificationSettings (settings);
        UIApplication.SharedApplication.RegisterForRemoteNotifications();
    }
    
