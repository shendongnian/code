	using (IDocumentStore store = GetDocumentStore())
	{
		store.Initialize();
		var subscriptionId = store.Subscriptions.Create(new SubscriptionCriteria<Person>());
		var personSubscription = store.Subscriptions.Open<Person>(subscriptionId, new SubscriptionConnectionOptions()
		{
			BatchOptions = new SubscriptionBatchOptions()
			{
				// Max number of docs that can be sent in a single batch
				MaxDocCount = 16 * 1024,  
				// Max total batch size in bytes
				MaxSize = 4 * 1024 * 1024,
				// Max time the subscription needs to confirm that the batch has been successfully processed
				AcknowledgmentTimeout = TimeSpan.FromMinutes(3)
			},
			IgnoreSubscribersErrors = false,
			ClientAliveNotificationInterval = TimeSpan.FromSeconds(30)
		});
		personSubscription.Subscribe(new PersonObserver());
		while (true)
		{
			Thread.Sleep(TimeSpan.FromMilliseconds(500));
		}
	}
