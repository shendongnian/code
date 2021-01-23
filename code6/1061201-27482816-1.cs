    var userId = 1;
    var subqueryByUser = QueryOver.Of<UserNotification>(() => pair)
        // now we do not need any kind of a join 
        // just have to filter these pairs related to user
        .Where(() => pair.User.Id == userId)
        // and get the notification Id
        .Select(x => pair.Notification.Id);
    var notificationsPerUser = session.QueryOver<Notification>(() => notification)
        .WithSubquery
            .WhereProperty(() => notification.Id)
            .In(subqueryByUser)
        .Where(() => !notification.IsRead)
        // if needed we can order
        // .OrderBy(...
        .Take(5)
        .List<Notification>()
