        [WebMethod]
        public CascadingDropDownNameValue[] FetchCountries()
        {
            GetLookupResponse countryLookupResponse = commonService.GetLookup("Country");
            List<CascadingDropDownNameValue> countries = new List<CascadingDropDownNameValue>();
            foreach (var dbCountry in countryLookupResponse.LookupItems)
            {
                string countryID = dbCountry.ID.ToString();
                string countryName = dbCountry.Description.ToString();
                countries.Add(new CascadingDropDownNameValue(countryName, countryID));
            }
            return countries.ToArray();
        }
        [WebMethod]
        public CascadingDropDownNameValue[] FetchStates(string knownCategoryValues)
        {
            int countryID;
            StringDictionary strCountries = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            countryID = Convert.ToInt32(strCountries["Country"]);
            GetLookupResponse stateLookupResponse = commonService.GetLookup("State");
            List<CascadingDropDownNameValue> states = new List<CascadingDropDownNameValue>();
            foreach (var dbState in stateLookupResponse.LookupItems.Where(id => id.DependencyID == countryID))
            {
                string stateID = dbState.ID.ToString();
                string stateName = dbState.Description.ToString();
                states.Add(new CascadingDropDownNameValue(stateName, stateID));
            }
            return states.ToArray();
        }
        [WebMethod]
        public CascadingDropDownNameValue[] FetchCities(string knownCategoryValues)
        {
            int stateID;
            StringDictionary strStates = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            stateID = Convert.ToInt32(strStates["State"]);
            GetLookupResponse cityLookupResponse = commonService.GetLookup("City");
            List<CascadingDropDownNameValue> cities = new List<CascadingDropDownNameValue>();
            foreach (var dbCity in cityLookupResponse.LookupItems.Where(id => id.DependencyID == stateID))
            {
                string cityID = dbCity.ID.ToString();
                string cityName = dbCity.Description.ToString();
                cities.Add(new CascadingDropDownNameValue(cityName, cityID));
            }
            return cities.ToArray();
        }
