    var projections = new[]
    {
        new { SymbolId = 1, Name = "", Date = DateTime.Now }, 
        new { SymbolId = 2, Name = "", Date = DateTime.Now }
    };
    var symbols = new[] { new { Id = 1 }, new { Id = 2 } };
    
    var result = 
    (from p in projections
                where p.SymbolId <= 42
                join s in symbols on p.SymbolId equals s.Id
                group p by p.SymbolId into g
                select new
                {
                    SymbolId = g.Key,
                    ProjectionPerformances =
                                g.Select(gg => new
                                {
                                    SymbolId = gg.SymbolId,
                                    Name = gg.Name,
                                    rpDate = gg.Date.ToString(),
                                }
                                            )
                }).ToDictionary(g => g.SymbolId);
