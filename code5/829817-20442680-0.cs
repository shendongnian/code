    static void Main()
    {
        Mutex mutex = new Mutex(false, "MyApp");
        if (mutex.WaitOne())
        {
            try
            {
                Application.Run(new Form1());
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
