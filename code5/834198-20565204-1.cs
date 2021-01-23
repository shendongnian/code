    var r = new Random();
    var collectionA = (from id in Enumerable.Range(0, 1000000)
                       select new
                       {
                         ID = id, 
                         Value1 = r.Next(1, 3),
                         Value2 = r.Next(0, 1) == 1,
                       }).ToList();
                       
    var collectionB = (from id in Enumerable.Range(58945, 1000000)
                       select new
                       {
                         ID = id, 
                         Value1 = r.Next(1, 3),
                         Value2 = r.Next(0, 1) == 1,
                       }).ToList();
    
    var timer = Stopwatch.StartNew();
    var changes = GetChanges(collectionA, collectionB, t => t.ID, t => new{t.Value1, t.Value2});
    timer.Stop();
    Console.WriteLine(new
    {
      changedIds = changes.ChangedKeys.Count, 
      newIds = changes.NewKeys.Count, 
      oldIds = changes.OldKeys.Count, 
      timer.ElapsedMilliseconds
    });
