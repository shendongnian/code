    ConnectionProfile internetConnectionProfile = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
                if (internetConnectionProfile == null)
                {
                   //logic ....
                }
    
                if (internetConnectionProfile != null)
                {
                    this.IsInternetAvailable = internetConnectionProfile.GetNetworkConnectivityLevel() ==
                                               NetworkConnectivityLevel.InternetAccess;
    
                    if (internetConnectionProfile.NetworkAdapter.IanaInterfaceType != 71)// Connection is not a Wi-Fi connection. 
                    {
                        var isRoaming = internetConnectionProfile.GetConnectionCost().Roaming;
    
                        //user is Low on Data package only send low data.
                        var isLowOnData = internetConnectionProfile.GetConnectionCost().ApproachingDataLimit;
    
                        //User is over limit do not send data
                        var isOverDataLimit = internetConnectionProfile.GetConnectionCost().OverDataLimit;
                        IsWifiConnected = true;
                        
                    }
                    else //Connection is a Wi-Fi connection. Data restrictions are not necessary. 
                    {
                        IsWifiConnected = true;
                        
                    }
                }
