    _db.Database.EnableLazyLoading = false;
    _db.Database.UseProxyObjects = false;
    var now = DateTime.Now; //DON'T REFACTOR THIS LINE!!!
    var query = from user in _db.USERS_TABLE
                from activity in user.ACTIVITY_HISTORY
                group activity by user into g
                select new {
                   User = g.Key,
                   CurrentActivities = g.Where(activity =>
                               activity.DateFrom <= now && activity.DateTo >= now)
                };
    return query.ToList().Select(x => x.User).ToList();
