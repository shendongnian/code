    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           LoadCountriesInDropDown(ddlCountry);
           ddlCountry.SelectedValue = "5" //For eg:
           LoadCitiesByCountrySelected(ddlCity, string selectedCountry);  // selected country value was set here as 5
           ddlCountry_SelectedIndexChanged(null, null);
        }
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlCountry.SelectedItem.Text == "Select")
        {
            ddlCity.Items.Clear();
        }
        else
        {
            LoadCitiesByCountrySelected(ddlCity, ddlCountry.SelectedValue);
        }
    
    }
