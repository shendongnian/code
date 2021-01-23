    IEnumerable<string> weeks = Enumerable.Range(0, 52)
        .Where((week, index) => index % 3 == 0)
        .Select(week => string.Format("Week {0}", week + 1));
    string allWeeks = String.Join(Environment.NewLine, weeks);
    Console.Write(allWeeks);
