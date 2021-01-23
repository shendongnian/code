        private static void TrackStatWithClicky(string eventValue)
        {
            // Prepare HTTP request
            WebRequest request = WebRequest.Create
           (
               "http://in.getclicky.com/in.php?" +
               "site_id=" + ClickySiteID +  //click site id , found in preferences
               "&sitekey_admin=" + ClickySiteAdminKey + //clicky site admin key, found in preferences
               "&ip_address=" + GetLocalIPAddressString() + //ip address of the user - used for mapping action trails
               "&type=custom" +
               "&href=" + eventValue.Replace(" ", "_") + //string that contains whatever event you want to track/log
               "&title=PBS Action" +
               "&type=click"
           );
            request.Method = "GET";
            // Get response
            WebResponse response = request.GetResponse();
            response.Close();
        }
        public static string GetLocalIPAddressString()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return "";
            }
    
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
    
            return host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
        }
