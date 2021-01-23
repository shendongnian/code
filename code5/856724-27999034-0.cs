    public static bool have_net()
        {
            ConnectionProfile InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
            if (InternetConnectionProfile == null) return false;
            NetworkConnectivityLevel ncl = InternetConnectionProfile.GetNetworkConnectivityLevel();
            if (ncl == NetworkConnectivityLevel.InternetAccess)
            {
                return true;
            }
            bool b1 = InternetConnectionProfile.IsWwanConnectionProfile;
            bool b2 = InternetConnectionProfile.IsWlanConnectionProfile;
            return (b1 || b2);
        }
