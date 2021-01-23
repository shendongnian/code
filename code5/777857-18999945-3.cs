    public ActionResult GetListOfCountriesForUserManufacturer(int userId, string manu)
    {
       manu = manu.Trim();
       //I'm not too crazy about sesiion usage, but that's a whole other issue
       var manuCountry = (Dictionary<string, List<string>>)Session["userManuCountry"];
       // get the specific countries for user and manufacturer
       var countries = manuCountry[manu];
       countries.Sort();
       ViewData["allCountries"] = new SelectList(countries);
       return View("CountriesParam");
    }
