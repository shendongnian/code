    var result = allTask.GroupBy(x => 1, x => x, (key, g) => new
    {
        All = g.Count(),
        Today = g.Count(t => t.DueDate != null && t.DueDate.Value.Date == DateTime.Now.Date),
        Tomorrow = g.Count(t => t.DueDate != null && t.DueDate.Value.Date == DateTime.Now.Date.AddDays(1))
    }).Single();
