    Teams.Join(Users.DefaultIfEmpty().
            t => t.TeamId,
            u => u.TeamId,
            (t, u) => new { t.TeamName, t.Description, UserId = u == null ? null:(int?)u.UserId })
        .GroupBy(x => x)
        .Select(g => new { g.Key.TeamName, g.Key.Description, Count = g.Count() });
