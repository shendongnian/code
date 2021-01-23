	public service TwitterStream : ??? <- an interface here?
	{
		...
		public TwitterStream (ILifetimeScope scope ??? <- IMO you don't need this...)
		{
			//Autofac/Twitter stuff
			...
			var context = GlobalHost.DependencyResolver.GetHubContext<TwitterHub>();
			_stream.MatchingTweetReceived += (sender, args) => {
				context.Clients.All.broadcast(args.Tweet);
			};
			//maybe more Autofac/Twitter stuff
			...
		}
        ...
	}
  
