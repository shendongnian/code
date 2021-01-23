    int groupSize = 2;
    
    var list = new List<Participants>();
    list.Add(new Participants { Name = "John", Order = 1, Override = false });
    list.Add(new Participants { Name = "Jane", Order = 2, Override = false });
    list.Add(new Participants { Name = "Ben", Order = 3, Override = false });
    list.Add(new Participants { Name = "Carl", Order = 4, Override = true });
    list.Add(new Participants { Name = "Jim", Order = 5, Override = false });
    
    // Group results every 2 records and
    // order them by Override (true to false) then Order (ascending)
    var ord = list.Select((o, i) => new { o = o, index = i }).GroupBy(o =>
    {
        return o.index / groupSize;
    }
    , o => o.o
    , (k, l) => l.OrderByDescending(o => o.Override).ThenBy(o => o.Order)).ToList();
