    var result = 
        from t in Tanks
        join tv in TankValues on t.ID equals tv.TankID
        group tv by new { t.ID, t.Description } into g
        orderby g.Key.Description descending  
        select new {
            Description = t.Key.Description,
            LogDate = g.OrderByDescending(x => x.LogDate).FirstOrDefault(),
            Level = g.OrderByDescending(x => x.LogDate).FirstOrDefault().LevelPercentTotal
        };
