    Rows = (from u in DB.Clients
            where u.Name.Contains(searchTerm) &&
                 !excludeTerms.Any(s => u.Name.Contains(s))
             select new ClientModel {
                  Name = u.FullName,
                  Id = u.Id,
             }).Take(5).ToList();
