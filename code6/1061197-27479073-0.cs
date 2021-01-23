    Occupation Notification= null;
    User user = null;
    var subquery = QueryOver.Of<Notification>(() => notification) 
        .Where(() => !notification.IsRead )
        // just related to the user, from outer query
        .Where(() => notification.User.ID == user.ID)
        .Select(x => notification.User.ID);
    var list = session.QueryOver<User>(() => user)
        .WithSubquery
            .WhereProperty(() => user.ID)
            .In(subquery)
        // paging
        .Take(10)
        .Skip(10)
        .List<User>();
