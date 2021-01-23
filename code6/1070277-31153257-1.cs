    public class Startup
    {
        [NoAutomaticTrigger]
        public static void Start(TextWriter log)
        {
            var token = new Microsoft.Azure.WebJobs.WebJobsShutdownWatcher().Token;
            //Shut down gracefully
            while (!token.IsCancellationRequested)
            {
                // Do somethings
            }
        }
    }
