    public static DateTime? TryGetDate(this string item)
    {
        DateTime d;
        bool success = DateTime.TryParse(item, out d);
        return success ? (DateTime?)d : (DateTime?)null;
    }
