        public bool IsNetworkAvailable()
        {
            if (DeviceNetworkInformation.IsNetworkAvailable)
            {
                if (Microsoft.Devices.Environment.DeviceType == DeviceType.Emulator)
                {
                    return true;
                }
                else if ((DeviceNetworkInformation.IsWiFiEnabled || DeviceNetworkInformation.IsCellularDataEnabled) && NetworkInterface.NetworkInterfaceType != NetworkInterfaceType.None)
                {
                    return true;
                }
            }
            return false;
        }
