        var users = (from i in db.Records
                             where i.Form.CompetitionID == cID
                             group i by new {i.Nickname} into g
                             orderby g.Count() descending, 
                             select new TopUserModel()
        {
            Nickname = g.Key,
            Position = g.Count()
            Date = g.Max(r => r.DateAdded)
        }).Take(100
    
    ).OrderBy(c => c.Date).ToList();
