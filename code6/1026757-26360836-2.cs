        /// <summary>
        /// The local WiFi connection status.
        /// </summary>
        /// <returns>
        /// The <see cref="NetworkStatus"/>.
        /// </returns>
        public static NetworkStatus LocalWifiConnectionStatus()
        {
            NetworkReachabilityFlags flags;
            return (!IsAdHocWiFiNetworkAvailable(out flags) || (flags & NetworkReachabilityFlags.IsDirect) == 0) ?
                NetworkStatus.NotReachable :
                NetworkStatus.ReachableViaWiFiNetwork;
        }
