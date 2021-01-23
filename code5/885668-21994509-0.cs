    User user = null;
    Role role = null;
    // the subselect, filtering the Roles, returning the user ID
    var subQuery = QueryOver.Of<Role>(() => role)
        .Where(() => role.ID == roleId)
        .Select(c => role.User.ID);
    // the query of the User, 
    // where at least one role fits the above subquery
    var query = session.QueryOver<User>(() => user)
        .WithSubquery
        .WhereProperty(() => user.Id)
        .In(subQuery);
