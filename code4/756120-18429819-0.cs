    var userJourney = repository.GetAllUsersWithJourneys();
    var searchView = new List<SearchViewModel>();
    try
    {	
        if (userJourneyList.Any())
        {
            foreach (var user in userJourney)
            {
                foreach(var journey in user.Journeys)
                {
                    searchView.Add(new SearchViewModel()
                        {
                            UserName = user.FirstName,
                            JourneyDestination = journey.JourneyDestination
                        });                
                }
            }
        }
	}
     catch (NullReferenceException ex)
     {
         // ... 
     }
