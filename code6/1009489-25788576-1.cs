    var results = db.Users.OfType<Business>()
              .Where(b => b.StateID == state && (term == null ||  b.Description.ToLower().Contains(term.ToLower())))
              .Select(x => new { id = x.StateID, value = x.Description })
              .Distinct()
              .Take(5)
              .ToList();
