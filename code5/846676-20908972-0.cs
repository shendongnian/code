    static class Program
    {
        private static SessionState sessionState = new SessionState() { SessionID = "100" };
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] servicesToRun;
            servicesToRun = new ServiceBase[] 
                {
                    new Service1(sessionState),
                    new Service2(sessionState)
                };
            ServiceBase.Run(servicesToRun);
        }
    }
