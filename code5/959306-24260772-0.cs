    var profile = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
    var interfaceType = profile.NetworkAdapter.IanaInterfaceType;
    // 71 is WiFi & 6 is Ethernet(LAN)
    if (interfaceType == 71 || interfaceType == 6) 
    {
    //TODO:
    }
    // 243 & 244 is 3G/Mobile
    else if (interfaceType == 243 || interfaceType == 244)
    {
     //TODO:
    }
