    [WebMethod]
    public IEnumerable<ThingsPrice> GetThings(string thing, decimal price)
    {
        List<ThingsPrices> things = new List<ThingsPrices>();
        things.Add(new ThingsPrice {"book", 0.50});
        things.Add(new ThingsPrice {"notepad", 1.20}); 
        return things; 
    } 
