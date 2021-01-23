        public void Fill()
        {
            List<CascadingDropDownNameValue> cities = new List<CascadingDropDownNameValue>();
            cities.AddRange(FetchCities(connectionString, knownCategoryValues, category));
            cities.Add(new CascadingDropDownNameValue("new city", "0"));
        }
        public IEnumerable<CascadingDropDownNameValue> FetchCities(string connectionString, string knownCategoryValues, string category)
        {
            StringDictionary strCountries = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            string CountryCode = strCountries["Country"].ToString();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("select * from Cities where Country=@Code Order by CityName ", con))
            {
                cmd.Parameters.Add("@Code", SqlDbType.VarChar).Value = CountryCode;
                using (SqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        string StateID = reader["CityID"].ToString();
                        string StateName = reader["CityName"].ToString();
                        yield return new CascadingDropDownNameValue(StateName, StateID);
                    }
            }
        }
