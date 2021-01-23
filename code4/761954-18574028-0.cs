    public void Fill()
    {
        List<CascadingDropDownNameValue> cities = new List<CascadingDropDownNameValue>();
        FetchCities(cities);
        cities.Add(....);
    }
    public void FetchCities(List<CascadingDropDownNameValue> values, string knownCategoryValues, string category)
    {
        string CountryCode;
        StringDictionary strCountries = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        CountryCode = strCountries["Country"].ToString();
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Cities where Country=@Code Order by CityName ", con);
        cmd.Parameters.AddWithValue("@Code", CountryCode);
        cmd.ExecuteNonQuery();
        SqlDataAdapter dastate = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        dastate.Fill(ds);
        con.Close();
        List<CascadingDropDownNameValue> states = new List<CascadingDropDownNameValue>();
        foreach (DataRow dtRow in ds.Tables[0].Rows)
        {
            string StateID = dtRow["CityID"].ToString();
            string StateName = dtRow["CityName"].ToString();
            values.Add(new CascadingDropDownNameValue(StateName, StateID));
        }
    }
