    public NetworkState GetNetworkState()
    {
        object ssid = null;
        NSDictionary dict = null;
        var status = CaptiveNetwork.TryCopyCurrentNetworkInfo("en0", out dict);
        if (status == StatusCode.OK)
            ssid = dict[CaptiveNetwork.NetworkInfoKeySSID];
        using (SystemConfiguration.NetworkReachability r = new NetworkReachability("www.appleiphonecell.com"))
        {
            NetworkReachabilityFlags flags;
            if (r.TryGetFlags(out flags))
            {
                if ((flags & NetworkReachabilityFlags.Reachable) != 0)
                {
                    if (ssid != null && !string.IsNullOrEmpty(ssid.ToString()))
                        return NetworkState.Wifi;
                    else
                        return NetworkState.Carrier;//we are not connected to wifi, but we can reach the site...
                }
            }
        }
        return NetworkState.None;
    }
