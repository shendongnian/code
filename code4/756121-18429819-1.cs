    var userJourney = repository.GetAllUsersWithJourneys();
    var searchView = userJourney.SelectMany(
        user => user.Journeys.Select(
            journey => new SearchViewModel()
                {
                    UserName = user.FirstName,
                    JourneyDestination = journey.JourneyDestination
                }
            )
        )
        .ToList();        
        
    if (!searchView.Any())
    {
        // no results logic
    }
