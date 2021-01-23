    var session = NHSession.GetCurrent();
    Notification notification = null;
    UserNotification pair = null;
    User user = null;
    var subquery = QueryOver.Of<UserNotification>(() => pair)
        // this will give us access to notification
        // see we can filter only these which are NOT read
        .JoinQueryOver(() => pair.Notification, () => notification)
        // here is the filter
        .Where(() => !notification.IsRead)
        // now the trick to take only related to our user
        .Where(() => pair.User.Id == user.Id)
        // and get the user Id
        .Select(x => pair.User.Id);
    var listOfUsers = session.QueryOver<User>(() => user)
        .WithSubquery
            .WhereProperty(() => user.Id)
            .In(subquery)
        // paging
        .Take(10)
        .Skip(10)
        .List<User>();
