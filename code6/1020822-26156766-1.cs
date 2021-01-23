    IEnumerable<string> thirdWeeks = Enumerable.Range(0, 52)
        .Where((week, index) => index % 3 == 0)
        .Select(week => string.Format("Week {0}", week + 1));
    string allWeeksInOneLine = String.Join(Environment.NewLine, thirdWeeks);
    Console.Write(allWeeksInOneLine);
