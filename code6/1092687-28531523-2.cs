    var users = data.GroupBy(p => p.Owner.Id).Select(g =>
    {
        var user = g.First().Owner;
        user.Posts = g.ToList();
        return user;
     });
