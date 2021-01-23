    public static DateTime? TryGetDate(this string item, params IFormatProvider[] formatProvider)
    {
        if (formatProvider.Length == 0)
            formatProvider = new[]{ CultureInfo.CurrentCulture };
        bool success = false;
        DateTime d = DateTime.MinValue;
        foreach (var provider in formatProvider)
        {
            success = DateTime.TryParse(item, provider, DateTimeStyles.None, out d);
            if (success) break;
        }
        return success ? (DateTime?)d : (DateTime?)null;
    }
