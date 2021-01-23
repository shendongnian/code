    string russianLines = @"
    13 сентября 2013 г., 11:27 пользователь написал:
    13 сентября 2013 г., 11:29 пользователь Вячеслав Равдин написал:
    13.09.2013, в 11:27, blablahblah...";
    CultureInfo ruCult = CultureInfo.CreateSpecificCulture("ru-RU");
    string[] formats = new[]{"dd MMMM yyyy", "dd.MM.yyyy"};
    string[] lines = russianLines.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    var lineDates = new List<DateTime?>();
    foreach (string line in lines)
    {
        string strDate = null;
        string[] tokens = line.Split(',');
        string[] parts = tokens.First().Split();
        if (parts.Length == 1)
            strDate = parts.First();
        else
            strDate = string.Join(" ", parts.Take(3));
        DateTime dt;
        if(DateTime.TryParseExact(strDate, formats, ruCult, DateTimeStyles.None, out dt))
            lineDates.Add(dt);
        else
            lineDates.Add(null);
    }
