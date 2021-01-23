    var data = db.Candidates
        .Where(c => ids.Contains(c.ID))
        .ToList() // <-- from here is Linq-To-Objects
        .Select(c => new
            {
                Id = c.Id,
                Email1 = c.Email1 ?? string.Empty,
                Name = c.Name 
            });
