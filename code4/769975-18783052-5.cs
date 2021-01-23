    var result = <someWayToGetTable1>.GroupBy(m => m.Name)
    .Select(m => new {
       name = m.Key,
       allDebit = m.Sum(x => x.debit),
    })
    .ToList()
    .Select((m, rn) => new {
        m.name,
        m.allDebit,
        rn
    });
