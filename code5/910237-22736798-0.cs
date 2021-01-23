    private static object _syncRoot = new object();
    private static int? dbValue;
    public static int GetNewDbValue()
    {
        if (dbValue == null)
        {
            // load db value from database
        }
        // lock ensures only one user can increment at a time
        lock (_syncRoot)
        {
            dbValue++;
            return dbValue;
        }
    }
