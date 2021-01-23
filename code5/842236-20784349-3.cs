    CompositeFilter filter = new CompositeFilter();
    CountryFilter countryFilter = new Countryfilter();
    countryFilter.Country = Country.Jamaica;
    
    filter.AddFilter(countryFilter);
    
    if(filter.TestFilter(person))
    {
     // pass
    }
