    public static void MainCode()
    {
        //SET A NAME HERE
        Thread.CurrentThread.Name = "Main thread"
        try
        {
            s_WorkingFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Log.Write("IvrApplication::MainCode() Starting...");
            // Start Other Threads...
            try
            {
