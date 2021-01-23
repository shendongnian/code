    public static bool IsMatch(this string source)
    {
        if (source == null) throw new ArgumentNullException("source");
        var parts = source.Split(',');
        if (parts.Any())
        {
            return parts.All(x => x.Length > 0 &&  x.All(char.IsDigit)) && parts.Skip(1).Count() == int.Parse(parts[0]);
        }
        return false;
    }
