    var enableIds = _db.items.Where(tble => tble.Date == null)
                             .GroupBy(a => a.Id)
                             .Select(g => new 
          { 
              Id = g.Key, 
              (EId = new List<int?>(g.Select(c => c.EId).Distinct())).Add(-1) 
          });
