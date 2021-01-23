    userEndpoint.LocalOwnerPresence.PresenceNotificationReceived += OnCategoryNotificationReceived;
    private static void OnCategoryNotificationReceived(object sender, LocalPresentityNotificationEventArgs e)
        {
            // Here you get the PresenceCategory and all the data of the user
            foreach (PresenceCategoryWithMetaData current in e.AllCategories)
            {
                if (current.Name == "routing" && current.ContainerId == 0 && current.InstanceId == 0L)
            // Creation of your Routing, I stock it in a Property 
                    _routingCategory = new Routing(current);
            }
            // I set my event to continue my main thread
            _routingCategoryUpdated.Set(); 
        }
