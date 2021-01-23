		private async Task FetchAllSocialPlatforms(Place bounds)
		{
			try
			{
				Task taskTwitter = FetchTwitter(bounds);
				Task taskInstagram = FetchInstagram(bounds);
				Task taskFlickr = FetchFlickr(bounds);
				Task taskYouTube = FetchYouTube(bounds);
				var complete = Task.WhenAll(taskTwitter, taskInstagram, taskFlickr, taskYouTube);
				await complete.ContinueWith((c) =>
				{
					SendNotificationOnComplete(...); // Azure Service Bus / SignalR message back to app
				});
			}
			catch (Exception ex)
			{
				Log.Error(...);
			}
		}
