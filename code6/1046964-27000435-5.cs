    var result = items.GroupBy(x => new { x.Week, x.IdEmployee })
                      .Select(x => new
                               {
                                  x.Key.Week,
                                  x.Key.IdEmployee,
                                  output = (from t in Enumerable.Range(1, 7)
                                  join w in x
                                  on t equals (int)w.Day.DayOfWeek into allitem
                                  from data in allitem.DefaultIfEmpty()
                                  select new 
                                  {
                                     Amount = data == null ? 0 : data.Amount
                                  }).ToList()
                              });
