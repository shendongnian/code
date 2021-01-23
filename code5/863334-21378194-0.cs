    public void AddCountryCollection()
    {                                  // <<< Put breakpoint here <<<
        newCountryClass = new NewCountryClass(newCountry, placeName);
        Collections.Add(newCountryClass);
        NTCD.Add(newCountryClass.Country, newCountryClass);    
    }
