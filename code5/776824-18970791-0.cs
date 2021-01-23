    public static class MyLogger
    {
        public static void Initialize()
        {
            if(IsWPFApplication())
                Application.Current.Exit += Application_Exit;
            
            //start flush thread and other initializations...
        }
        private static bool IsWPFApplication()
        {
            Dispatcher dispatcher = Dispatcher.FromThread(Thread.CurrentThread);
            return (dispatcher != null);
        }
        private static void Application_Exit(Object sender, EventArgs e)
        {
            Shutdown();
        }
        
        private static void Shutdown()
        {
            ExitRequested = true;
        }
    }
