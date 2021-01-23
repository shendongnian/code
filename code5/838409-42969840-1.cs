    public static bool TcpSocketTest()
    {
        try
        {
            System.Net.Sockets.TcpClient client =
               new System.Net.Sockets.TcpClient("www.google.com", 80);
            client.Close();
            return true;
        }
        catch (System.Exception ex)
        {
            return false;
        }
    }
