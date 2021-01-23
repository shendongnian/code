    someAction
    {
        CountryModel objcountrymodel = new CountryModel();  
        objcountrymodel.CountryList = GetAllCountryList();
        return View(objcountrymodel);
    }
    public SelectList GetAllCountryList()
    {
        List<Country> objcountry = new List<Country>();
        objcountry.Add(new Country { Id = 1, CountryName = "India" });
        objcountry.Add(new Country { Id = 2, CountryName = "USA" });
        objcountry.Add(new Country { Id = 3, CountryName = "Pakistan" });
        objcountry.Add(new Country { Id = 4, CountryName = "Nepal" });
        SelectList objselectlist = new SelectList(objcountry, "Id", "CountryName");
        return objselectlist;
    }
