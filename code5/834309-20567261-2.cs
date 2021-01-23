    Rows = (from u in DB.Clients
            where u.Name.Contains(searchTerm)                 
            select new ClientModel {
                  Name = u.FullName,
                  Id = u.Id,
            }).AsEnumerable()
              .Where(m => !excludeTerms.Any(s => m.Name.Contains(s)))
              .Take(5).ToList();
