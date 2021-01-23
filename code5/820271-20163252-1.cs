    var collection = Enumerable.Range(1, 3);
                
    // Average reimplemented with Aggregate.
    double average = collection
        .Aggregate(
            new { Count = 0, Sum = 0 },
            (acc, i) => new { Count = acc.Count + 1, Sum = acc.Sum + i })
        .Apply(a => (double)a.Sum / (double)a.Count); // Note: we have access to both Sum and Count despite never having stored the result of the call to .Aggregate().
               
    Console.WriteLine("Average: {0}", average);
