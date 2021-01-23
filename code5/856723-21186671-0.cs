    public static bool IsInternetAvailable
    {
        get
        {
            var profiles = NetworkInformation.GetConnectionProfiles();
            var internetProfile = NetworkInformation.GetInternetConnectionProfile();
            return profiles.Any(s => s.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
                || (internetProfile != null
                        && internetProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess);
        }
    }
    if(App.IsInternetAvailable)
    {
        //Do operation of Bing map
    }
    else
    {
        //Show message dialog
    }
