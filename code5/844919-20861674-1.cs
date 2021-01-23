    var input = string.Format(
        " 11-20 2690 E 28.76 12-02 2468 E* 387.85{0}11-15 3610 E 29.34 12-87 2534 E",
        Environment.NewLine);
    var pattern = string.Format(@" ({0}-\d{{2}}) ", DateTime.Now.ToString("MM"));
    var lines = new List<string>();
    foreach (var line in input.Split(new string[] { Environment.NewLine },
        StringSplitOptions.RemoveEmptyEntries))
    {
        var m = Regex.Match(line, pattern);
        if (!m.Success)
        {
            continue;
        }
        DateTime dt;
        if (!DateTime.TryParseExact(m.Value.Trim(),
            "MM-dd",
            null,
            DateTimeStyles.None,
            out dt))
        {
            continue;
        }
        lines.Add(line);
    }
