    public static DateTime AsUtc(this DateTime value)
    {
        if (value.Kind == DateTimeKind.Unspecified)
        {
            return new DateTime(value.Ticks, DateTimeKind.Utc);
        }
        return value.ToUniversalTime();
    }
