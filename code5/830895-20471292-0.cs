    var sample = "{01/01/13 00:00:00, 02/01/13 00:00:00}";
        sample = sample.Substring(1, sample.Length - 2);    // removes {}
    var values = sample
        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(value =>
        {
            DateTime aux;
            if (DateTime.TryParseExact(value, "dd/MM/yy HH:mm:ss", null,
                                DateTimeStyles.AllowWhiteSpaces, out aux))
                return aux as DateTime?;
            return null;
        })
        .Where (date => date != null)
        .ToList();
    foreach (var date in values)
    {
        Console.WriteLine(date.Value.Day);
    }
