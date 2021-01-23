    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        string countryID = string.Empty;
        NavigationContext.QueryString.TryGetValue("id", out countryID);
        System.Diagnostics.Debug.WriteLine(string.Concat("URI: ", e.Uri.ToString(), " | CountryID: ", countryID));
        if (!string.IsNullOrWhiteSpace(countryID))
        {
            Guid countryGuid = new Guid();
            Guid.TryParse(countryID, out countryGuid);
            Country country = App.Countries.Where(x => x.CountryID == countryGuid).Select(x => x).FirstOrDefault();
            if (country != null)
            {
                // ***** BUILD YOUR PAGE AS NEEDED HERE *****
                // TextBlock1.Text = country.Name; 
            }
        }
    }
