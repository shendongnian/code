    public static class GlobalState
    {
        private static HashSet<string> _ipAddresses;
        public static HashSet<string> IPAddresses
        {
            get
            {
                if (_ipAddresses == null) _ipAddresses = new HashSet<string>();
                return _ipAddresses
            }
        }
    }
