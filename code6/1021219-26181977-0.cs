    protected void UploadString(string address, string method, string data)
    {
        using (WebClient webClient = new WebClient())
        {
            bool success = false;
            int tryCount = 0;
            while (!success && tryCount++ < 3)
            {
                try
                {
                    webClient.UploadString(address, method, data);
                    success = true;
                }
                catch (WebException)
                {
                    Log.Audit(1, tryCount, address, method);
                }
            }
        }
    }
