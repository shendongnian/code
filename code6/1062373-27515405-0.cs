    public override string ReadString()
    {
        if (readingDate)
        {
            string dateString = base.ReadString();
            DateTime dt;
            if (!DateTime.TryParse(dateString, out dt))
                dt = DateTime.ParseExact(dateString, CustomUtcDateTimeFormat, CultureInfo.InvariantCulture);
            return dt.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
        }
        else
        {
            return base.ReadString();
        }
    }
