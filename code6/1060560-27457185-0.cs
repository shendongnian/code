    list.GroupBy(i => i.Agent_ID)
    .Select(g => new Agent // Strong class
    { 
       Agent_ID= g.Key.Agent_ID,
       Name = g.First().Name,
       Calls = g.Sum(i => i.Calls)
    })
