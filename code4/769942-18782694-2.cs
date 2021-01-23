    string russianLines = @"
    13 сентября 2013 г., 11:27 пользователь написал:
    13 сентября 2013 г., 11:29 пользователь Вячеслав Равдин написал:
    13.09.2013, в 11:27, blablahblah...";
    CultureInfo ruCult = CultureInfo.CreateSpecificCulture("ru-RU");
    string[] formats = new[]{"dd MMMM yyyy", "dd.MM.yyyy"};
    string[] lines = russianLines.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    IEnumerable<DateTime?> lineDates = lines
        .Select(l => { 
            string strDate = null;
            string[] tokens = l.Split(',');
            string[] parts = tokens.First().Split();
            if(parts.Length == 1)
                strDate = parts.First();
            else
                strDate = string.Join(" ", parts.Take(3));
            return strDate.TryGetDate(ruCult, formats);
        })
        .ToList();
