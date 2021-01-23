    var eventyears = storeDB.EventMasters
                         .GroupBy(c=>c.EventYear)
                         .Select(items=>items.First())
                         .SelectMany(item->item)
                           .ToList()
                           .OrderByDescending(c => c.EventYear == c.EventYear.Distinct());
