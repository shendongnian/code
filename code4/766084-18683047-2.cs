    var projectsByApp = projects.SelectMany(p => p.Applications
                                                  .Select(a => new { p, a }))
                                .GroupBy(x => x.a)
                                .Select(g => new {
                                                Application = g.Key,
                                                Projects = g.Select(x => p).ToList())
                                             })
                                .ToList();
