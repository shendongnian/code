    records
        .GroupBy(x => new { x.Div, x.Bus, x.Dept })
        .Select(g => new 
            { 
                g.Key.Div, 
                g.Key.Bus, 
                g.Key.Dept, 
                Entered = g.Count(r => r.Status == Entered),
                Progress= g.Count(r => r.Status == Progress),
                Finished= g.Count(r => r.Status == Finished),
            });
