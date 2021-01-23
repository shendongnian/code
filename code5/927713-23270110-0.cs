    private DateTime getDateTimeField(string dbValue)
    {
        if (dbValue == null)
        {
            return new DateTime();
        }
        else {
            return DateTime.Parse(dbValue);
        }
    }
