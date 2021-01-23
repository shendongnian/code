                ConnectionProfile internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
                if (internetConnectionProfile == null)
                {
                    Debug.WriteLine("CanPerformODOperations: not connected to Internet");
                    return OneDriveStatus.noInternetConnection;
                }
                if (App.Settings.UnrestrictedDownloads)
                {
                    Debug.WriteLine("CanPerformODOperations: app settings set to unrestricted downloads");
                    return OneDriveStatus.OK;
                }
                if (internetConnectionProfile.GetNetworkConnectivityLevel() != NetworkConnectivityLevel.InternetAccess)
                {
                    Debug.WriteLine("CanPerformODOperations: not got Internet access");
                    return OneDriveStatus.noUnrestrictedNetwork;
                }
                ConnectionCost cost = internetConnectionProfile.GetConnectionCost();
                if (cost == null || cost.NetworkCostType == NetworkCostType.Unrestricted)
                {
                    Debug.WriteLine("CanPerformODOperations: cost is null or unrestricted");
                    return OneDriveStatus.OK;
                }
                Debug.WriteLine("CanPerformODOperations: not got an unrestricted network");
                return OneDriveStatus.noUnrestrictedNetwork;
