        var data = db.Candidates
            .Where(c => ids.Contains(c.ID))
            .Select(c => new
                {
                    Id = c.Id,
                    Email1 = c.Email1 ?? string.Empty,
                    Name = c.Name 
                });
        foreach(var row in data)
        {
            var name = row.Name // etc...
        }
