    private static string FormatFilename(string pattern, DateTime dt)
    {
        return Regex.Replace(pattern, @"\{(.*)\}", match =>
        {
            string format = match.Result("$1").Replace("m", "M");
            return dt.ToString(format, CultureInfo.InvariantCulture);
        });
    }
