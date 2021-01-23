    var summary = from esc in objs
        where esc.time.Month == month && esc.time.Year == year
        group esc by esc.rlf_id
        into g
        select new
        {
            ID = g.Key,
            Total = g.Count(),
            Preventable = g.Count(a => a.preventable)
        };
    var orders = new[]
    {
        new OrderByPropertyName {Desc = true, PropertyName = "Preventable"},
        new OrderByPropertyName {Desc = false, PropertyName = "ID"},
        new OrderByPropertyName {Desc = true, PropertyName = "Total"},
    };
    var firstOrder = orders.First();
    var dynSummary = firstOrder.Desc
        ? summary.AsQueryable().OrderByDescending(firstOrder.PropertyName)
        : summary.AsQueryable().OrderBy(firstOrder.PropertyName);
    dynSummary = orders.Except(new[] {firstOrder})
        .Aggregate(dynSummary, (current, order) => order.Desc
            ? current.ThenByDescending(firstOrder.PropertyName)
            : current.ThenBy(firstOrder.PropertyName));
