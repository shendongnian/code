        // Register for push notifications.
            public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                var authOptions = UserNotifications.UNAuthorizationOptions.Alert | UserNotifications.UNAuthorizationOptions.Badge | UserNotifications.UNAuthorizationOptions.Sound;
                UserNotifications.UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) =>
                {
                    Console.WriteLine(granted);
                });
                UIApplication.SharedApplication.RegisterForRemoteNotifications();
            }
            else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, new NSSet());
                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
                UIApplication.SharedApplication.RegisterForRemoteNotifications();
            }
            else
            {
                var notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
            }
    
    }
    private SBNotificationHub Hub { get; set; }
            public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
            {
    
                Hub = new SBNotificationHub(Constants.ListenConnectionString, Constants.NotificationHubName);
    //if user is not logged In
                Employee employee = JsonConvert.DeserializeObject<Employee>(Settings.CurrentUser);
                if (employee != null)
                {
    
                    NSSet tags = new NSSet(new string[] { "username:" + employee.Email }); // create tags if you want
                    Hub.RegisterNativeAsync(deviceToken, tags, (errorCallback) =>
                        {
                            if (errorCallback != null)
                                Console.WriteLine("RegisterNativeAsync error: " + errorCallback.ToString());
                        });
                }
                else
                {
                    Hub.UnregisterAllAsync(deviceToken, (error) =>
                    {
                        if (error != null)
                        {
                            Console.WriteLine("Error calling Unregister: {0}", error.ToString());
                            return;
                        }
                    });
                }
            }
    
    
    public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
            {
                AzurePushNotificationManager.RemoteNotificationRegistrationFailed(error);
            }
            public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
            {
                ProcessNotification(userInfo, false);
            }
            void ProcessNotification(NSDictionary options, bool fromFinishedLaunching)
            {
                // Check to see if the dictionary has the aps key.  This is the notification payload you would have sent
                if (null != options && options.ContainsKey(new NSString("aps")))
                {
                    //Get the aps dictionary
                    NSDictionary aps = options.ObjectForKey(new NSString("aps")) as NSDictionary;
    
                    string alert = string.Empty;
    
                    if (aps.ContainsKey(new NSString("alert")))
                        alert = (aps[new NSString("alert")] as NSString).ToString();
    
                    if (!fromFinishedLaunching)
                    {
                        //Manually show an alert
                        if (!string.IsNullOrEmpty(alert))
                        {
                            NSString alertKey = new NSString("alert");
                            UILocalNotification notification = new UILocalNotification();
                            notification.FireDate = NSDate.Now;
                            notification.AlertBody = aps.ObjectForKey(alertKey) as NSString;
                            notification.TimeZone = NSTimeZone.DefaultTimeZone;
                            notification.SoundName = UILocalNotification.DefaultSoundName;
                            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
                        }
                    }
                }
            }
