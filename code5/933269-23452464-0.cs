    NetworkStateTracker()
    {
      DetermineNetworkState();
      DeviceNetworkInformation.NetworkAvailabilityChanged += OnNetworkAvailabilityChanged;
    }
    void OnNetworkAvailabilityChanged(object sender, NetworkNotificationEventArgs args)
    {
      DetermineNetworkState();
    }
    void DetermineNetworkState()
    {
      bool bIsCellularConnected = false;
      bool bIsWiFiConnected = false;
      NetworkInterfaceList netInfoList = new NetworkInterfaceList();
      foreach (NetworkInterfaceInfo netInfo in netInfoList)
      {
        if (netInfo.InterfaceState == ConnectState.Connected)
        {
          switch (netInfo.InterfaceType)
          {
            case NetworkInterfaceType.MobileBroadbandCdma:
            case NetworkInterfaceType.MobileBroadbandGsm:
              bIsCellularConnected = true;
              break;
            case NetworkInterfaceType.Wireless80211:
              bIsWiFiConnected = true;
          }
        }
      }
      // Do something with the Network
    }
