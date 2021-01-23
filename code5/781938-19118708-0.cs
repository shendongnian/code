    var maxCount = db.Users.Count() * 0.2;
    var query = (from u in db.Users
            group u by u.Email.Split('@')[1] into g
            select new 
            {
                Domain = g.Key,
                Users = g.Take(maxCount).ToList()
            })
            .SelectMany(x => x.Users);
