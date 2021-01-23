    public static TimeSpan? TryParseTimeSpan(string input)
    {
        TimeSpan? ts = (TimeSpan?)null;
        if (!string.IsNullOrWhiteSpace(input))
        {
            input = input.Trim();
            int length = input.Length % 2 == 0 ? input.Length : input.Length + 1;
            int count = length / 2;
    
            if(count > 3) return null;
    
            input = input.PadLeft(count * 2, '0');
    
            string[] validFormats = new[] { "HHmmss", "mmss", "ss" };
            DateTime dt;
            if (DateTime.TryParseExact(input, validFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                ts = dt.TimeOfDay; 
        }
        return ts;
    }
