    var enableIds = _db.items.Where(tble => tble.Date == null)
                             .GroupBy(a => a.Id)
                             .Select(g => new 
          { 
              Id = g.Key, 
              EId = Concat(g.Select(c => c.EId).Distinct(), -1) 
          });
            public static IEnumerable<T> Concat<T>(IEnumerable<T> enumerable, params T[] enumerable2)
            {
                if (enumerable == null) throw new ArgumentNullException("enumerable");
                if (enumerable2 == null) throw new ArgumentNullException("enumerable2");
                foreach (T t in enumerable)
                {
                    yield return t;
                }
    
                foreach (T t in enumerable2)
                {
                    yield return t;
                }
            }
