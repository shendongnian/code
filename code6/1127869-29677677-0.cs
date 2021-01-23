    var res = ecml
        .SelectMany(m => new[] {
            new { User = m.SentFrom, m.SendDate }
        ,   new { User = m.SentTo, m.SendDate }
        })
        .GroupBy(p => p.User)
        .Select(g => new {
            User = g.Key
        ,   Last = g.OrderByDescending(m => m.SendDate).First()
        });
