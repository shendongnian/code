      public bool Start(ActivityType activity = ActivityType.Other, bool alsoWhenInBackground = false, LocationAccuracy accuracy = LocationAccuracy.AccurracyBestForNavigation,
                          double minDistanceBetweenUpdatesInMeters = 0, TimeSpan? maxDelayBetweenUpdates = null)
        {
            if (manager != null)
                return true;
            manager = new CLLocationManager();
            manager.Failed += (sender, args) => FireError(args.Error.ToString());
            manager.LocationsUpdated += (sender, args) => FireLocationUpdated(args.Locations);
            //manager.AuthorizationChanged
            manager.ActivityType = (CLActivityType)activity;
            manager.DesiredAccuracy = Accuracies[(int)accuracy];
            if (maxDelayBetweenUpdates != null || minDistanceBetweenUpdatesInMeters > double.Epsilon)
                manager.AllowDeferredLocationUpdatesUntil(minDistanceBetweenUpdatesInMeters, (maxDelayBetweenUpdates ?? TimeSpan.Zero).TotalSeconds);
           
            if (alsoWhenInBackground)
                manager.PausesLocationUpdatesAutomatically = true;
            //Required: ask for authorization
            if (AuthorizationStatus == AuthorizationStatus.NotDetermined)
                AskAuthorization(alsoWhenInBackground);
            var authStatus = AuthorizationStatus;
            if (authStatus < AuthorizationStatus.AuthorizedAlways && authStatus != AuthorizationStatus.NotDetermined)
            {
                System.Diagnostics.Debug.WriteLine("user denied access to location");
                return false;
            }
            if (authStatus == AuthorizationStatus.AuthorizedWhenInUse && alsoWhenInBackground)
            {
                System.Diagnostics.Debug.WriteLine("alsoWhenInBackground is true, but user denied access to location in background");
                return false;
            }
            manager.StartUpdatingLocation();
            return true;
        }
    public bool AskAuthorization(bool alsoWhenInBackground = false)
        {
            if (AuthorizationStatus != AuthorizationStatus.NotDetermined)
                return false;
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                if (alsoWhenInBackground)
                    manager.RequestAlwaysAuthorization();
                else
                    manager.RequestWhenInUseAuthorization();
            }
            return true;
        }
