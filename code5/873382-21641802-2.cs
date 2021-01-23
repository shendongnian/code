    private bool TryParseIso8601(string s, out DateTime result)
    {
        if (!string.IsNullOrEmpty(s))
        {
            string format = s.EndsWith("Z") ? "yyyy-MM-ddTHH:mm:ssZ" : "yyyy-MM-ddTHH:mm:sszzz";
            return DateTime.TryParseExact(s, format, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out result);
        }
        result = new DateTime(0L, DateTimeKind.Utc);
        return false;
    }
