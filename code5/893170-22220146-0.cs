    var query = db.Entity
        .GroupBy(x => new { x.A, x.B, x.C })
        .Select(g => new Entity { 
            A = g.Key.A, B = g.Key.B, C = g.Key.C,
            D = String.Join(",", g.Select(x => x.D))
        });
