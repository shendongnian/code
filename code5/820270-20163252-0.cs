    var collection = Enumerable.Range(1, 3);
                
    // Average reimplemented with Aggregate.
    int average = collection
        .Aggregate(
            new { Count = 0, Sum = 0 },
            (acc, i) => new { Count = acc.Count + 1, Sum = acc.Sum + i })
        .Apply(a => a.Sum / a.Count);
               
    Console.WriteLine("Average: {0}", average);
