        private void YourMethod()
        {
             if (InternetConnection) {
               
               // Your code connecting to server
             }
        }
        public static bool InternetConnection()
        {
            return NetworkInformation.GetInternetConnectionProfile().GetNetworkConnectivityLevel() >= NetworkConnectivityLevel.InternetAccess;
        }
