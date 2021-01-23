    private bool roaming;
        private string connectionProfileInfo;
        private async Task<bool> IsConnectedToInternet()
        {
            HttpWebRequest webReq;
            HttpWebResponse resp = null;
           // HttpStatusCode respcode;
            Uri url = null;
            url = new Uri("http://www.dartinnovations.com");
            webReq = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                resp = (HttpWebResponse)await webReq.GetResponseAsync();
              //  Debug.WriteLine(resp.StatusCode);
                webReq.Abort();
                webReq = null;
                url = null;
                resp = null;
                return true;
            }
            catch
            {
                webReq.Abort();
                webReq = null;
                return false;
            }
        }
        private async Task<bool> CheckForConnection()
        {
            bool isConnected = await IsConnectedToInternet();
            Debug.WriteLine(isConnected);
            ConnectionProfile internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
           
    
            if (isConnected)
            {
                if (internetConnectionProfile != null)//Gets metereing info, Connectionprofile gives false positives when used to check for internet connectivity
                {
                    Debug.WriteLine("internet available");
                    GetMeteringInformation(internetConnCectionProfile);
                }
                else
                {
                    connectionProfileInfo = "Roaming information not available";
                    roaming = false;
                   // Debug.WriteLine("no connections");
                }
                return true;
               
            }           
            return false;
            
        }
      private async Task GetMeteringInformation(ConnectionProfile connectionProfile)
        {
            ConnectionCost connectionCost = connectionProfile.GetConnectionCost();
            roaming = connectionCost.Roaming;
            connectionProfileInfo = "Over Data Limit :" + connectionCost.OverDataLimit + " | Approaching Data Limit :" +
                                    connectionCost.ApproachingDataLimit;
        }
