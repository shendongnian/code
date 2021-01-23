    var perYearAndPerMonth = articles.GroupBy(a => a.Year)
                                     .Select(yearGroup => new
                                     {
                                         Year = yearGroup.Key,
                                         PerMonth = yearGroup.GroupBy(a => a.Month)
                                                             .Select(monthGroup => new
                                                             {
                                                                 Month = monthGroup.Key,
                                                                 Articles = monthGroup.ToList()
                                                             })
                                     });
