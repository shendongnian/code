        public static string ApplicationName {
            get {
                if (_applicationName == null) {
                    throw new InvalidOperationException("You *must* assign the ApplicationName property before this library is usable");
                }
                return _applicationName;
            }
            set { _applicationName = value; }
        }
        private static string _applicationName;
