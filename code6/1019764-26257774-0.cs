    var cfg = new BusConfiguration();
    // Set up all the settings with the new V5 Configuration API
	using (var justOneBus = NServiceBus.Bus.Create(cfg).Start())
	{
		// Use justOneBus, then it gets disposed when done.
	}
