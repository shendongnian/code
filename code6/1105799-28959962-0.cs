    var result= _db.Surveys.AsNoTracking()
                   .GroupBy(x => x.City)
                   .Select(group => new 
                          {
                                City = group.Key.Code, 
                                CityName = group.Key.Name, 
                                Count = group.Count(),
                                SatisfactionRatio = (group.Count(y => y.Satisfaction == 1 ) * 100) / group.Count()
                          })
                   .OrderByDescending(x => x.Count);
