    ...
    select new TopUserModel()
    {
    	Nickname = g.Key,
    	Position = g.Count()
    	Date = g.Max(r => r.DateAdded)
    }).Take(100).OrderBy(t => t.Date).ToList();
