    class RegistraionWrapper
    {
        private static Object _lock = new Object();
        public static void DoWork(int ID)
        {
            lock (_lock)
            {
                RegistrationManager.RegisterConfiguration(ID);
                RegistrationManager.DoWork();
                RegistrationManager.UnregisterConfiguration(ID);
            }
        }
    }
