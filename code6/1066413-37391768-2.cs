    public class Connection
    {
       public bool CheckInternetAccess()
       {
            var connectionProfile = NetworkInformation.GetInternetConnectionProfile();
            var HasInternetAccess = (connectionProfile != null &&
                                 connectionProfile.GetNetworkConnectivityLevel() ==
                                 NetworkConnectivityLevel.InternetAccess);
            return HasInternetAccess;
       }
    }
