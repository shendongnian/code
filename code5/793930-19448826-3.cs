    public bool CheckInternetConnection()
    {
        bool success = false;
        using (Ping ping = new Ping())
        {
            try
            {
                if (ping.Send("google.com", 2000).Status == IPStatus.Success)
                {
                    success= true;
                }
            }
            catch (PingException)
            {
                success = false;
            }
        }
        return success;
    }
