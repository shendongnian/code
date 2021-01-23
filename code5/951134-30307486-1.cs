    using Windows.Networking.Connectivity;
    /// <summary>
    /// Detect the current connection type
    /// </summary>
    /// <returns>
    /// 2 for 2G, 3 for 3G, 4 for 4G
    /// 100 for WiFi
    /// 0 for unknown or not connected</returns>
    private static byte GetConnectionGeneration()
    {
        ConnectionProfile profile = NetworkInformation.GetInternetConnectionProfile();
        if (profile.IsWwanConnectionProfile)
        {
            WwanDataClass connectionClass = profile.WwanConnectionProfileDetails.GetCurrentDataClass();
            switch (connectionClass)
            {
                //2G-equivalent
                case WwanDataClass.Edge:
                case WwanDataClass.Gprs:
                    return 2;
                //3G-equivalent
                case WwanDataClass.Cdma1xEvdo:
                case WwanDataClass.Cdma1xEvdoRevA:
                case WwanDataClass.Cdma1xEvdoRevB:
                case WwanDataClass.Cdma1xEvdv:
                case WwanDataClass.Cdma1xRtt:
                case WwanDataClass.Cdma3xRtt:
                case WwanDataClass.CdmaUmb:
                case WwanDataClass.Umts:
                case WwanDataClass.Hsdpa:
                case WwanDataClass.Hsupa:
                    return 3;
                //4G-equivalent
                case WwanDataClass.LteAdvanced:
                    return 4;
                //not connected
                case WwanDataClass.None:
                    return 0;
                //unknown
                case WwanDataClass.Custom:
                default:
                    return 0;
            }
        }
        else if (profile.IsWlanConnectionProfile)
        {
            return 100;
        }
        return 0;
    }
