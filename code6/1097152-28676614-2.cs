    var _i = (from a in _db.WebPersonalInfos 
              group a by a.Email into g 
              where g.Count() > 1 
              orderby g.Key 
              select new {
                 LastName = g.First().LastName, 
                 FirstName = g.First().FirstName, 
                 Email = g.Key, 
                 Count = g.Count()
              })
             .ToList();
