    private static List<ILog> _logs = new List<ILog>();
    public static ILog GetLogger(string name)
    {
        return _logs.SingleOrDefault(a => a.Logger.Name == name);
    }
