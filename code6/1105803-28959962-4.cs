    var result= _db.Surveys.AsNoTracking()
                   .GroupBy(x => new 
                                {
                                  City =x.City,
                                  Name =x.Name
                                 })
                   .Select(group => new 
                          {
                                City = group.Key.Code, 
                                CityName = group.Key.Name, 
                                Count = group.Count(),
                                SatisfactionRatio = (group.Count(y => y.Satisfaction == Satisfaction.VerySatisfied || y.Satisfaction == Satisfaction.Satisfied) * 100) / group.Count()
                          })
                   .OrderByDescending(x => x.Count);
