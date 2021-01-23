     public static void ConnectUs()
    {		
    		
    		IPHostEntry ipHostInfo = System.Net.Dns.GetHostEntry( "serveraddress.com");
    		IPAddress ipAddress = ipHostInfo.AddressList[0];
    		
            using (TcpClient client = new TcpClient())
            {
                
    		client.Connect(ipAddress, 21);
    		client.SendTimeout = 3000;
    		var status = client.Connected;
                Console.WriteLine(status);
            }
    }
