    public static bool InternetTest()
        {
            try
            {
                string site = "http://www.google.com/";
                TcpClient client = TcpClient(site, 80);
                client.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
