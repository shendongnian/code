    public bool ValidateDate(string dateInput)
    {
        Regex datePattern = new Regex(@"^(1[0-2]|0[1-9])/(3[01]|[12][0-9]|0[1-9])/[0-9]{4}$"); 
        return !datePattern.IsMatch(dateInput);
    }
