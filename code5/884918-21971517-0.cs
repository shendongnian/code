    public string DbDateTime(string input)
    {
        return DateTime.ParseExact(input,
                                   "MM/dd/yyyy h:mm:ss tt", 
                                   CultureInfo.InvariantCulture).
                                   ToString();
    }
