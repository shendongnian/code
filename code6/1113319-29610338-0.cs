	// Set Persistent view in class constructor
	var persistentSettings = new RemotePresenceViewSettings();
	persistentSettings.SubscriptionMode = RemotePresenceViewSubscriptionMode.Persistent;            	
	this.PersistentPresenceView = new RemotePresenceView(this.AppEndpoint, persistentSettings);
	// Listen to SubscriptionStateChanged  and PresenceNotificationReceived  events
	this.PersistentPresenceView.SubscriptionStateChanged += this.RemotePresenceView_SubscriptionStateChanged;
	this.PersistentPresenceView.PresenceNotificationReceived += this.RemotePresenceView_NotificationReceived;
    // Call below public method to subscribe to user Lync Presence
    public void SubscribeToPresences(List<string> emailAddressList)
    {
		var subscriptionTargets = new List<RemotePresentitySubscriptionTarget>();
		var subscribedPresentities = this.PersistentPresenceView.GetPresentities();
		if (emailAddressList != null && emailAddressList.Count > 0)
		{
			foreach (var email in emailAddressList)
			{
				try
				{
					var target = new RemotePresentitySubscriptionTarget("sip:"+email);
                    if (!subscribedPresentities.Contains(presence.EmailAddress))
                    {
			 	   	    subscriptionTargets.Add(target);
                    }
				}
				catch (ArgumentException argumentException)
				{                                
					// ToDO: Handle exception
				}
				catch (RealTimeException realTimeException)
				{                             
					// ToDO: Handle exception
				}
				
			}
		}
	}
	// Subscription changed event
    private void RemotePresenceView_SubscriptionStateChanged(object sender, RemoteSubscriptionStateChangedEventArgs e)
    {  
		foreach (KeyValuePair<RealTimeAddress, RemotePresentityStateChange> stateChanged in e.SubscriptionStateChanges)
		{
			if (view != null)
			{
				Console.WriteLine("\nView: " + view.ApplicationContext
								  + "; Subscription State for user: "
								  + stateChanged.Key /* uri of subscription target */
								  + " has changed from: " + stateChanged.Value.PreviousState
								  + " to: " + stateChanged.Value.State + ".");
			}
		}
    }
	// Notification received event
	private void RemotePresenceView_NotificationReceived(object sender, RemotePresentitiesNotificationEventArgs e)
	{
		foreach (RemotePresentityNotification notification in e.Notifications)
		{
			//// If a category on notification is null, the category
			//// was not present in the notification. This means there were no
			//// changes in that category.
			if (notification.AggregatedPresenceState != null)
			{
				Console.WriteLine("Email Address: " + notification.PresentityUri.Split(':')[1]+ " Aggregate State = " + notification.AggregatedPresenceState.Availability + ".");
			}
		}
	}
