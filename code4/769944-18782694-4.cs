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
