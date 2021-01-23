	[HttpPost]
	public void Post(IEnumerable<InstagramUpdate> instagramUpdates)
	{
		foreach (var instagramUpdate in instagramUpdates)
		{
			if (WaitingToProcessSubscriptionUpdate(instagramUpdate.Subscription_id))
			{
				// Ongoing request, do nothing
			}
			else
			{
			    // Process update
			}
		}
	}
	private bool WaitingToProcessSubscriptionUpdate(string subscriptionId)
	{
		// Check in the in memory cache if this subscription is in queue to be processed. Add it otherwise
		var queuedRequest = _cache.AddOrGetExisting(subscriptionId, string.Empty, new CacheItemPolicy
		{
			// Automatically expire this item after 1 minute (if update failed for example)
			AbsoluteExpiration = DateTime.Now.AddMinutes(1)
		});
		return queuedRequest != null;
	}
