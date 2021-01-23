    public static bool CheckForInternetConnection()
    {
        try
        {
            using (var client = new WebClient())
            using (var stream = client.OpenRead("http://www.bing.com"))
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
