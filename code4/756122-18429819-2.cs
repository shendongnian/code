    public IList<SearchViewModel> GetSearchViewModels()
    {
        using (var db = new EfDbContext())
        {
            var users = from user in db.Users
                        from journey in user.Journeys
                        select new SearchViewModel()
                        {
                            UserName = user.FirstName,
                            JourneyDestination = journey.JourneyDestination
                         }
                        select userJourney;
            return users.ToList();
        }
    } 
