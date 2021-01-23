    ICriteria crit = CurrentSession.CreateCriteria(typeof(City))
        .CreateAlias("Streets", "Street", JoinType.InnerJoin)
        .Add(Expression.InsensitiveLike("Name", "London", MatchMode.Exact))
        .Add(Expression.InsensitiveLike("Street.Name", "Pic%", MatchMode.Exact))
        .SetProjection(Projections.List()
            .Add(Projections.Property("Name"))
            .Add(Projections.Property("Street.Name")));
    
    
    var results1 = crit.List<object[]>()
        .Select(arr => new LocationDto
                       {
                           CityName = (string)arr[0],
                           StreetName = (string)arr[1]
                       });
    // or if it is really needed
    var results2 = crit.List<object[]>()
        .Select(arr => new City
                       {
                           Name = (string)arr[0],
                           Streets = { new Street((string)arr[1]) }
                       });
