        /// <summary>
        /// Gets the current SSID.
        /// </summary>
        /// <value>The current SSID.</value>
        public string CurrentSSID 
        {
            get
            {
                NSDictionary dict;
                var status = CaptiveNetwork.TryCopyCurrentNetworkInfo ("en0", out dict);
                if (status == StatusCode.NoKey)
                {
                    return string.Empty;
                }
                var bssid = dict [CaptiveNetwork.NetworkInfoKeyBSSID];
                var ssid = dict [CaptiveNetwork.NetworkInfoKeySSID];
                var ssiddata = dict [CaptiveNetwork.NetworkInfoKeySSIDData];
                return ssid.ToString();
            }
        }
