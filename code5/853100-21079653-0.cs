    // Get current Internet Connection Profile.
    ConnectionProfile internetConnectionProfile = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
    
    // Check the connection details.
    if (internetConnectionProfile.NetworkAdapter.IanaInterfaceType != IANA_INTERFACE_TYPE_WIFI)
    {
        // Connection is not a Wi-Fi connection. 
        if (internetConnectionProfile.GetConnectionCost().Roaming)
        {
            // User is roaming. Don't send data out.
            m_bDoNotSendData = true;
        }
    
        if (internetConnectionProfile.GetConnectionCost().ApproachingDataLimit)
        {
            // User is approaching data limit. Send low-resolution images.
            m_bSendLowResolutionImage = true;
        }
    
        if (internetConnectionProfile.GetConnectionCost().OverDataLimit)
        {
            // User is over data limit. Don't send data out.
            m_bDoNotSendData = true;
        }
    }
    else
    {   
        //Connection is a Wi-Fi connection. Data restrictions are not necessary.                        
        m_bDoNotSendData = false;
        m_bSendLowResolutionImage = false;
    }
    
    // Optionally, report the current values in a TextBox control.
    string cost = string.Empty;
    switch (internetConnectionProfile.GetConnectionCost().NetworkCostType)
    {
        case NetworkCostType.Unrestricted:
            cost += "Cost: Unrestricted";
            break;
        case NetworkCostType.Fixed:
            cost += "Cost: Fixed";
            break;
        case NetworkCostType.Variable:
            cost += "Cost: Variable";
            break;
        case NetworkCostType.Unknown:
            cost += "Cost: Unknown";
            break;
        default:
            cost += "Cost: Error";
            break;
    }
    cost += "\n";
    cost += "Roaming: " + internetConnectionProfile.GetConnectionCost().Roaming + "\n";
    cost += "Over Data Limit: " + internetConnectionProfile.GetConnectionCost().OverDataLimit + "\n";
    cost += "Approaching Data Limit : " + internetConnectionProfile.GetConnectionCost().ApproachingDataLimit + "\n";
    
    NetworkStatus.Text = cost;
