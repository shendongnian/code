    var now = DateTime.Now; //DON'T REFACTOR THIS LINE!!!
    var query = from user in _db.USERS_TABLE
                group user.ACTIVITY_HISTORY by user into g
                select new {
                   User = g.Key,
                   CurrentActivities = g.Where(activity =>
                               activity.DateFrom <= now && activity.DateTo >= now)
                };
    return query.ToDictionary(x => x.User, x => x.CurrentActivities.ToList());
