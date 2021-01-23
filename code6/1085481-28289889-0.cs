    public static bool CheckInternetConnection()
    {
        return checkInternet().IsSuccessful;
    }
    public async static Task<bool> CheckInternetConnectionAsync()
    {
        if (NetworkInterface.GetIsNetworkAvailable())
        {
            return await Task.Run(() => CheckInternetConnection());
        }
        return false;
    }
