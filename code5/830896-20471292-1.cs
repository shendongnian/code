    var sample = "{01/01/13 00:00:00, 02/01/13 00:00:00}";
    var values = Regex.Matches(sample, @"\d{2}/\d{2}/\d{2} \d{2}:\d{2}:\d{2}")
        .OfType<Match>()
        .Select(value =>
        {
            DateTime aux;
            if (DateTime.TryParseExact(value.Value, "dd/MM/yy HH:mm:ss",
                    null, DateTimeStyles.AllowWhiteSpaces, out aux))
                return aux as DateTime?;
            return null;
        })
        .Where (date => date != null)
        .ToList();
    foreach (var date in values)
        Console.WriteLine(date.Value.Day);
