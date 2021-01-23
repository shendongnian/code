    var allTheStrings = new List<string>();
    Parallel.For(0, 
      maxIter, 
      () => new List<string> (), // Setup for each task
      (i, pls, localStrings) =>
      {
         // The "tight" loop. If you need to synchronize here, there is no point of
         // using parallel
         localStrings.Add(i.ToString());
         return localStrings;
      },
      (localStrings) => // Finally for each task.
      {
         // Synchronization here is kind of ok - run once per task.
         lock(allTheStrings)
         {
            allTheStrings.AddRange(localStrings);
         }
      });
