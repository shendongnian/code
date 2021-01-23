    var ranges = new[]{
        new{ Start=0, End=1500 },  new{ Start=1501, End=2500}, new{ Start=2501, End=4000}
    }.ToList();
    var players = new[]{
        new{ Name = "Tom", Score = 1000 },
        new{ Name = "Mark", Score = 2200 },
        new{ Name = "Antony", Score = 3000 },
        new{ Name = "Paul", Score = 2500 },
        new{ Name = "Kris", Score = 2800 },
        new{ Name = "Ron", Score = 3110 },
    };
    var scoreGroups = players.
        GroupBy(p => ranges.FindIndex(r => p.Score >= r.Start && p.Score <= r.End));
    foreach (var scoreGroup in scoreGroups)
        Console.WriteLine("Range: {0} <--> {1} Players: {2}"
            , ranges[scoreGroup.Key].Start
            , ranges[scoreGroup.Key].End
            , string.Join(", ", scoreGroup.Select(p => p.Name));
