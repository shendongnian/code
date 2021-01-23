    void ProcessAccount1()
    {
        var countries = Enum.GetValues(typeof(Country)).Cast<Country>();
        foreach (var country in countries)
        {
            // do some operation
        }
    }
