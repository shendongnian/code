    static public string GetStringRegistryValue(string key, string defaultValue)
    {
        RegistryKey rkCompany;
        RegistryKey rkApplication;
        rkCompany = Registry.CurrentUser.OpenSubKey(SOFTWARE_KEY, 
                    false).OpenSubKey(COMPANY_NAME, false);
        if( rkCompany != null )
        {
            rkApplication = rkCompany.OpenSubKey(APPLICATION_NAME, true);
            if( rkApplication != null )
            {
                foreach(string sKey in rkApplication.GetValueNames())
                {
                    if( sKey == key )
                    {
                    return (string)rkApplication.GetValue(sKey);
                    }
                }
            }
        }
        return defaultValue;
    }
