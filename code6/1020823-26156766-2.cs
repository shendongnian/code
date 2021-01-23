    var weeksGrouped = thirdWeeks
        .Select((week, index) => new { week, index })
        .GroupBy(x => x.index / 3)
        .Select(g => String.Join("\t", g.Select(x => x.week)));
    string allWeeksGrouped = String.Join(Environment.NewLine, weeksGrouped);
    Console.Write(allWeeksGrouped);
