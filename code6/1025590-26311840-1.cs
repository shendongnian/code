    countryComboBox.ItemsSource = GetCountryList();
    public static List<string> GetCountryList()
    {
        List<string> cultureList = new List<string>();
    
        CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
    
        foreach (CultureInfo culture in cultures)
        {
            RegionInfo region = new RegionInfo(culture.LCID);
    
            if (!(cultureList.Contains(region.EnglishName)))
            {
                cultureList.Add(region.EnglishName);
            }
        }
        return cultureList;
    }
