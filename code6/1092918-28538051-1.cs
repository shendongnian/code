    public static bool ConnectionTest()
        {
            try
            {
                string site = "http://www.google.com/";
                TcpClient client = TcpClient(site, 80);
                client.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
