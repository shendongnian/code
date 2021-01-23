    DataTable tblCountries = new DataTable();
    // add all columns ...
    foreach(Country c in allCountries)
    {
        if(Companies.Any())
        {
            foreach(var company in c.Companies)
            {
                var row = tblCountries.Rows.Add();
                row.SetField("Name", c.Name);
                row.SetField("Countrycode", c.Countrycode);
                row.SetField("CompanyName", company.CompanyName);
                // add the other company fields ...
            }
        }
        else  // add just the country and let the company cells be null
        {
            var row = tblCountries.Rows.Add();
            row.SetField("Name", c.Name);
            row.SetField("Countrycode", c.Countrycode);
        }
    }
