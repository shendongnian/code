    public List<MobileVenueModel> GetGyms( string applicationId )
    {
        return _eventRepository.DataContext
            .EventGyms
            .Where( GetGymPredicateExpression( applicationId ) )
            .ToList();
    }
    
    public Expression<Func<EventGym, bool>> GetGymPredicateExpression( string applicationId )
    {
        return eg => GetEvent( applicationId ).Compile().Invoke( eg.Event );
    }
