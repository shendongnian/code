    var titles = regexTitles.Matches(pageContent).Cast<Match>();
    var dates = regexDate.Matches(pageContent).Cast<Match>();
    var source = titles.Zip(dates, (t, d) => new { Title = t, Date = d })
    foreach (var item in source)
    {
        var articleTitle = item.Title.Groups[1].Value;
        var articleDate = item.Date.Groups[1].Value;
        Console.WriteLine(articleTitle);
        Console.WriteLine(articleDate);
    }
