    public bool ValidateDate(string dateInput)
    {
        DateTime dt;
        return DateTime.TryParseExact(dateInput, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
    }
