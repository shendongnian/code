    private DateTime IsDate(string toCheck)
    {
        DateTime dt = new DateTime();
        if (DateTime.TryParse(toCheck, out dt))
            dt = DateTime.Parse(toCheck);
        else
            dt = DateTime.Parse("1900/01/01");
    
        return dt;
    }
