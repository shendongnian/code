    static object lockerObject = new object();
    static string GetUniqueKey()
    {
        lock (lockerObject)
        {
           return DateTime.Now.ToString("yyyyMMddHHmmssf");
           Thread.Sleep(100);
        }
    }
