    public static string GetRidOfZeros(string input)
    {
        var dt = DateTime.ParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        return dt.ToString("d.M.yyyy", CultureInfo.InvariantCulture);
    }
