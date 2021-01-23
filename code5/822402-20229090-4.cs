    public List<MobileVenueModel> GetGyms( string applicationId )
    {
        return _eventsRepository.DataContext
            .EventGyms
            .Where( GetEventGymPredicateExpression( applicationId ) )
            .Select( eg => new MobileVenueModel() { Id = eg.Id } )
            .ToList()
    }
   
