    GetAllPersonsFilteredBy(string name, bool filterName, int age, bool filterAge, Country? country, bool filterCountry)
    {
        List<Person> allPersons = getAllPersons();
        if (filterName != null)
            //filter all persons out the list based on the name parameter
              ...
        if (filterAge != null)
            //filter all persons out the list based on the age parameter
              ...
        if(filterCountry.HasValue)
        {
            Country countryValue = filterCountry.Value;
            //filter all persons out of the list based on the country parameter
             ...
        }
    return allPersons;
