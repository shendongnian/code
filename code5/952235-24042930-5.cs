		private async Task FetchTwitter(Place bounds)
		{
			var t = Task.Run(() =>
			{
				int count = 0;
				try
				{
					count = Fetch(bounds, PlatformType.Twitter);
				}
				catch (Exception ex)
				{
					Log.Error(...);
				}
				SendNotificationOnComplete(count, ...); // Azure Service Bus / SignalR message back to app
			});
			await t;
		}
