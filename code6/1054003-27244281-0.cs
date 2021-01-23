    var tmp =
        from u in Users
            join ua in UserApplications on u.Id equals ua.UserId
            join a in Applications on ua.ApplicationId equals a.Id
        select new
            {
                User = u,
                App = a
            };
    var res = tmp
        .GroupBy(_ => _.User)
        .Select(_ => new 
            {
                User = _.Key, 
                Applications = _.Select(_ => _.App).ToArray()
            });
