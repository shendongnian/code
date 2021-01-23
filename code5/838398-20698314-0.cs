    public static bool checkNetworkConnection()
            {
                var ni = NetworkInterface.NetworkInterfaceType;
    
                bool IsConnected = false;
                if (ni == NetworkInterfaceType.Wireless80211)
                    IsConnected= true;
                else if (ni == NetworkInterfaceType.None)
                    IsConnected= false;
                return IsConnected;
            }
