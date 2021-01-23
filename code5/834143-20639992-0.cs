    public static class ServiceRunner
    {
        private static bool IsAzureWorker
        { 
            get { return !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("RoleRoot")); } 
        }
        public static void Run(string[] args)
        {
            if (IsAzureWorker)
            {
                //Running as Azure Worker
            }
            else if (Environment.UserInteractive) //note, this is true for Azure emulator too
            {
                //Running as Console App
            }
            else
            {
                //Running as Windows Service
            }
        }
    }
    
