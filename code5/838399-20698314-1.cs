     public static bool checkNetworkConnection()
                {
                    var ni = NetworkInterface.NetworkInterfaceType;
        
                    bool IsConnected = false;
                    if ((ni == NetworkInterfaceType.Wireless80211)|| (ni == NetworkInterfaceType.MobileBroadbandCdma)|| (ni == NetworkInterfaceType.MobileBroadbandGsm))
                        IsConnected= true;
                    else if (ni == NetworkInterfaceType.None)
                        IsConnected= false;
                    return IsConnected;
                }
