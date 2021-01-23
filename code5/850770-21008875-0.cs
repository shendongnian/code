       var grouped = primaryData.Select(x => new { ID = x.Key, 
                                                   Data1 = subData1[x.Key],
                                                   Data2 = subData2[x.Key] }).ToList();
       Parallel.ForEach(grouped, (item) => 
       {
           item.Data1.Results = new Results(item.ID, item.Data2);
           item.Data1.Status = new Status(item.ID, item.Data2);
       });
    
       results.Add(key, grouped);
