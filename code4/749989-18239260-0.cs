    Logs.GroupBy(t => t.LogDate).Select(g => new {
        Date = g.Key,
        Details = g.GroupBy(t => t.Robot).Select(g => new {
            Robot = g.Key,
            TaskStates = g.ToDictionary(t => t.Task, t => t.State)
        }).ToList()
    })
