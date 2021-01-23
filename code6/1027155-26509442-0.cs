    foreach(var line in data.GroupBy(info => info.metric)
                            .Select(group => new { 
                                 Metric = group.Key, 
                                 Count = group.Count() 
                            })
                            .OrderBy(x => x.Metric)
    {
         Console.WriteLine("{0} {1}", line.Metric, line.Count);
    }
