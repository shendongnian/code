    DateTime[] data = analyticRepo.GetAll()
                                  .Where(x => DbFunctions.TruncateTime(x.DateCreated) == report.DateCreated.Date)
                                  .Select(x => x.DateCreated)
                                  .AsEnumerable() // transition to Linq-to-Objects
                                  .Select(x => new DateTime(
                                      x.Year,
                                      x.Month,
                                      x.Day,
                                      x.Hour,
                                      x.Minute,
                                      x.Second,
                                      x.Millisecond))
                                  .ToArray();
