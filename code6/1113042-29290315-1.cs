    var start = DateTime.Now.StartOfWeek();
    var end = DateTime.Now.EndOfWeek();
    var games = db.Games
                .Where(x => x.Date >= start && x.Date <= end )
                .OrderBy(x => x.Team.MinAge)
                .ToList();
