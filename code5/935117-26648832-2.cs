    public static class IpProvider
    {
        private static readonly Lazy<string> _localAddress;
        private static readonly Lazy<string> _broadcastAddress;
        static IpProvider()
        {
            _localAddress = new Lazy<string>(GetLocalAddress);
            _broadcastAddress = new Lazy<string>(GetBroadcastAddress);
        }
        public static string LocalAddress { get { return _localAddress.Value; } }
        public static string BroadcastAddress { get { return _broadcastAddress.Value; } }
        private static string GetLocalAddress()
        {
            var hostnames = NetworkInformation.GetHostNames();
            foreach (var hn in hostnames)
            {
                //IanaInterfaceType == 71 => Wifi
                //IanaInterfaceType == 6 => Ethernet (Emulator)
                if (hn.IPInformation != null &&
                    (hn.IPInformation.NetworkAdapter.IanaInterfaceType == 71
                     || hn.IPInformation.NetworkAdapter.IanaInterfaceType == 6))
                {
                    return hn.DisplayName;
                }
            }
            return IpAddress.Broadcast.Address;
        }
        private static string GetBroadcastAddress()
        {
            var parts = _localAddress.Value.Split(new[] { '.' }).Take(3);
            return string.Join(".", parts) + ".255";
        }
    }
