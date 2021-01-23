    _eventAggregator.GetEvent<UserAuthenticatedEvent>()
        .Subscribe(
        o =>
        {
            Console.WriteLine("Requesting navigation...");
            _regionManager.RequestNavigate(
                RegionNames.ContentRegion,
                new Uri(WellKnownViewNames.RosterView, UriKind.Relative));
        });
