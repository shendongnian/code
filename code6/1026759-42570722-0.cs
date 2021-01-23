    private bool CheckConnectivity()
        {
            var isConnected = CrossConnectivity.Current.IsConnected;
            return isConnected;
        }
