    public static Expression<Func<Event,bool>> GetEvent( string applicationId )
    {
        var arg = Expression.Parameter( typeof( Event ), "e" );
        return ( Expression<Func<Event, bool>> )Expression.Lambda( GetEvent( arg, applicationId ), arg );
    }
    public static Expression<Func<EventGym, bool>> GetEventGymPredicateExpression( string applicationId )
    {
        var arg = Expression.Parameter( typeof( EventGym ), "eg" );
        var propSelector = Expression.Property( arg, "Event" );
        var existingExp = GetEvent( propSelector, applicationId );
        return ( Expression<Func<EventGym, bool>> )Expression.Lambda( existingExp, arg );
    }
    public static Expression GetEvent( Expression arg, string applicationId )
    {
        // q.Active
        var activeProp = Expression.Property( arg, "Active" );
        // q.Visible
        var visibleProp = Expression.Property( arg, "Visible" );
        // q.Active && q.Visible
        var and0 = Expression.AndAlso( activeProp, visibleProp );
        var meaProp = arg.Type.GetProperty( "MobileEventApplications" );
        var colType = meaProp.PropertyType;
        var entityType = colType.GetGenericArguments().Single();
        var mArg = Expression.Parameter( entityType, "m" );
            
        // m.MobileApplication
        var maProp = Expression.Property( mArg, "MobileApplication" );
        // m.MobileApplication.ApplicationId
        var appIdProp = Expression.Property( maProp, "ApplicationId" );
        // m.MobileApplication.ApplicationId == applicationId
        var appIdEqual = Expression.Equal( appIdProp, Expression.Constant( applicationId ) );
        // m.MobileApplication.ActivationLength
        var alProp = Expression.Property( maProp, "ActivationLength" );
        // m.MobileApplication.ActivationLength.HasValue
        var hvProp = Expression.Property( alProp, "HasValue" );
        // !m.MobileApplication.ActivationLength.HasValue
        var notHasValue = Expression.Not( hvProp );
        // DbFunctions.AddDays( DateTime.Now, 1 )
        var addDaysFunc = typeof( DbFunctions ).GetMethods().Single( mi => 
            mi.Name == "AddDays" && 
            mi.GetParameters().First().ParameterType == typeof( DateTime? ) );
        var nowPlus1d = Expression.Call( null, addDaysFunc, Expression.Constant( DateTime.Now, typeof( DateTime? ) ), Expression.Constant( 1, typeof( int? ) ) );
        // m.MobileApplication.DateActivated
        var daProp = Expression.Property( maProp, "DateActivated" );
        // m.MobileApplication.ActivationLength.Value
        var alvProp = Expression.Property( alProp, "Value" );
        // DbFunctions.AddMonths( DateActivated, ActivationLength.Value )
        var addMonthsFunc = typeof( DbFunctions ).GetMethods().Single( mi => 
            mi.Name == "AddMonths" &&
            mi.GetParameters().First().ParameterType == typeof( DateTime? ) );
        var addMonths = Expression.Call( null, addMonthsFunc, Expression.Convert( daProp, typeof( DateTime? ) ), Expression.Convert( alvProp, typeof( int? ) ) );
        // AddDays < AddMonths
        var ltOp = Expression.LessThan( nowPlus1d, addMonths );
        // !HasValue || ( AddDays < AddMonths )
        var orOp = Expression.Or( notHasValue, ltOp );
        // AppId == applicationId && ( !HasValue || ( AddDays < AddMonths ) )
        var anyBody = Expression.AndAlso( appIdEqual, orOp );
        var anyPredicate = Expression.Lambda( anyBody, mArg );
        // q.MobileEventApplications
        Expression meaExp = Expression.Property( arg, meaProp );
        var anyMethod = typeof( Queryable ).GetMethods()
            .Single( mi => 
                mi.Name == "Any" && 
                mi.GetParameters().Count() == 2 )
            .MakeGenericMethod( entityType );
        // q.MobileEventApplications.Any( m => anyBody )
        var anyCallExp = Expression.Call( null, anyMethod, Expression.Convert( meaExp, typeof( IQueryable<MobileEventApplication> ) ), anyPredicate );
        return Expression.AndAlso( and0, anyCallExp );
        //return q => q.Active && q.Visible && q.MobileEventApplications.Any(m =>
        //    m.MobileApplication.ApplicationId == applicationId &&
        //    (
        //        !m.MobileApplication.ActivationLength.HasValue || 
        //        DbFunctions.AddDays(DateTime.Now, 1) < DbFunctions.AddMonths(m.MobileApplication.DateActivated, m.MobileApplication.ActivationLength.Value ) ) );
    }
