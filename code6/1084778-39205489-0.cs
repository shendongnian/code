    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
        /* 
        // Your init code, for ex.
        global::Xamarin.Forms.Forms.Init();
        LoadApplication(new App(string.Empty));
        */                                                      
    
        if (options != null)
            if (options.Keys != null)
                if (options.Keys.Count() != 0)
                {
                    UILocalNotification localnotif = null;
    
                    if (options.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
                        localnotif = options.ObjectForKey(UIApplication.LaunchOptionsLocalNotificationKey) as UILocalNotification;
    
                    if (localnotif != null)
                    {
    
                        UIAlertView alert = new UIAlertView()
                        {
                            Title = "LocalNotification",
                            Message = string.Format("Content: {0}, {1}", localnotif.AlertTitle, localnotif.AlertBody)
                        };
                        alert.AddButton("OK");
                        alert.Show();                                        
                    } 
                }
    
        return base.FinishedLaunching(app, options);
    }
