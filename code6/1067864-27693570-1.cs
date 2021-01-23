    List<MontlySales> result = coll1.Concat(coll2)
                      .GroupBy(x => new { x.Year, x.Month })
                      .Select(x => new MonthlySales
                      {
                          Year = x.Key.Year,
                          Month = x.Key.Month,
                          Sales = x.Sum(z => z.Sales)
                      }).ToList();
