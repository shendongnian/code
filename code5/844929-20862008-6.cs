    var grouped = list.GroupBy(a => a.PostDate.Year)
                  .Select(a => new { Year = a.Key, Items = a.GroupBy(i => i.PostDate.Month)
                                                            .Select(i => new { Month = i.Key, Titles = i.Select(t => t.Title)})
    														.OrderBy(i => i.Month)})
    		      .OrderBy(a => a.Year);
