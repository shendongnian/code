    var firstDate = yourDict.First().Key;
    var output = yourDict.GroupBy(e=> (int)(e.Key - firstDate).TotalMinutes / 5)
                         .ToDictionary(g => g.First().Key
                                           .AddMinutes(g.Average(e=>(e.Key - g.First().Key).TotalMinutes)),
                                       g => g.Average(e=>e.Value));
