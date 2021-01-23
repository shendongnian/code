    public DateTime ParseString(string value)
    {
        CultureInfo[] cultures = {CultureInfo.CurrentCulture, 
                                  new CultureInfo("en-US"), 
                                  new CultureInfo("de-DE")};
        
        foreach(var cult in cultures)
        {
            DateTime dt;
            if (DateTime.TryParse(value, cult, DateTimeStyles.None, out dt))
                return dt;
        }
        throw new ArgumentException(
            string.Format("Unable to parse DateTime for string {0}.", value));
    }
