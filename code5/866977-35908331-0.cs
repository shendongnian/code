    public static bool ConnectToAPNS(string deviceId, string message)
        {
            X509Certificate2Collection certs = new X509Certificate2Collection();
            // Add the Apple cert to our collection
            certs.Add(getServerCert());
            // Apple development server address
            string apsHost;
            /*
            if (getServerCert().ToString().Contains("Production"))
                apsHost = "gateway.push.apple.com";
            else*/
            apsHost = "gateway.sandbox.push.apple.com";
            // Create a TCP socket connection to the Apple server on port 2195
            TcpClient tcpClient = new TcpClient(apsHost, 2195);
            // Create a new SSL stream over the connection
            SslStream sslStream1 = new SslStream(tcpClient.GetStream());
            // Authenticate using the Apple cert
            sslStream1.AuthenticateAsClient(apsHost, certs, SslProtocols.Default, false);
            PushMessage(deviceId, message, sslStream1);
            return true;
        }
    private static X509Certificate getServerCert()
        {
            X509Certificate test = new X509Certificate();
            //Open the cert store on local machine
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            if (store != null)
            {
                // store exists, so open it and search through the certs for the Apple Cert
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certs = store.Certificates;
                if (certs.Count > 0)
                {
                    int i;
                    for (i = 0; i < certs.Count; i++)
                    {
                        X509Certificate2 cert = certs[i];
                        if (cert.FriendlyName.Contains("Apple Development IOS Push Services"))
                        {
                            //Cert found, so return it.
                            Console.WriteLine("Found It!");
                            return certs[i];
                        }
                    }
                }
                return test;
            }
            return test;
        }
    private static byte[] HexToData(string hexString)
        {
            if (hexString == null)
                return null;
            if (hexString.Length % 2 == 1)
                hexString = '0' + hexString; // Up to you whether to pad the first or last byte
            byte[] data = new byte[hexString.Length / 2];
            for (int i = 0; i < data.Length; i++)
                data[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return data;
        }
