    public static TimeZoneInfo FindSystemTimeZoneById(string id)
    {
        if (string.Compare(id, "UTC", StringComparison.OrdinalIgnoreCase) == 0)
        {
            return Utc;
        }
        // etc..
    }
