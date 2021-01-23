    var v =
        from c in Computers
        // First outer join.
        join m in Monitors on c.ComputerId equals m.ComputerId into monitor
        from m in monitors.DefaultIfEmpty()
    
        // Group by the computers
        group new { m } by new { c } into g
        select new 
        {
            Computer = g.Key.c,
            Ports = g.Select(i => i.m).SelectMany(i => i.Port).ToList(),
        };
