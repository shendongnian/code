    Thread thread = new Thread(() => ConnectionCheck());
    thread.Start();
    ...
    public static void ConnectionCheck()
    {
         bool result = CheckForInternetConnection();
         //Do something with result
    }
