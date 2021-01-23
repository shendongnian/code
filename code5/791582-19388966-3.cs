    private static System.Threading.Mutex m = new System.Threading.Mutex(false, "LockMutex");
    void AccessMethod()
    {
        try
        {
            m.WaitOne();
            // Access the file
        }
        finally
        {
            m.ReleaseMutex();
        }
    }
