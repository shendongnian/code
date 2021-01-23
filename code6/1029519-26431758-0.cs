                var result = from c in countries
                         join conty in counties on c.id equals conty.CountryId
                         join city in cities on conty.id equals city.CountyId
                         group city by c.Name into g
                         select new
                         {
                             Name = g.Key,
                             Cities = g.Select(x =>
                                 new
                                 {
                                     x.Name,
                                     x.Population
                                 })
                         };
