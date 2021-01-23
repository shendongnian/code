    public Expression<Func<EventGym,bool>> GetEventGymPredicateExpression( string applicationId )
    {
        // define arg of expression
        var arg = Expression.Parameter( typeof( EventGym ), "eg" );
            
        // define property selector expression (e.g. `eg.Event`)
        var propSelector = Expression.Property( arg, "Event" );
            
        // apply existing Event predicate to the Event property
        var invokeExp = Expression.Invoke( GetEvent( applicationId ), propSelector );
        // put the pieces together
        return ( Expression<Func<EventGym,bool>> )Expression.Lambda( invokeExp, arg );
    }
    
