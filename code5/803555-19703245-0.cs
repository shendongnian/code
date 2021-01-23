    public static DateTime? TryParseDateTime(string text)
    {
        DateTime validDate;
        return DateTime.TryParse(text, out validDate) ? validDate : (DateTime?) null;
    }
