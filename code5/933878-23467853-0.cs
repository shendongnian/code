    public bool IsValidTime(string time)
    {
        DateTime dummyDate;
        return DateTime.TryParseExact(time, new[] { "HH:mm", "H:mm" }, 
            CultureInfo.InvariantCulture, 
            DateTimeStyles.NoCurrentDateDefault, out dummyDate);
    }
