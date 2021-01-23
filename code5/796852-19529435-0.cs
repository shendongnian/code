    var maxUserAlertId = QueryOver.Of<UserAlert>
                                 .Select(
                                     Projections.Max(
                                        Projections.Property<UserAlert>
                                                          (u => u.UserAlertId)
                                     )
                                   );
    var maxUserQuery = session
                         .QueryOver<UserAlert>()
                         .WithSubquery
                             .WhereProperty(u => u.EntityId)
                             .Eq(maxUserAlertId);
    // Dealing with the situation that the maximum value is shared
    // by more than one row. If you're certain that it can only
    // be one, call SingleOrDefault instead of List
    IList<UserAlert> results = maxUserQuery.List();
