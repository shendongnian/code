    public static void GetLines(Action<string> callback)
    {
        ThreadPool.QueueUserWorkItem(_ =>
        {
            callback(File.ReadAllText(_path, new UnicodeEncoding()));
        });
    }
