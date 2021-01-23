		private static void Main()
        {
            try
            {
                string baseAddress = ConfigurationManager.AppSettings["ApiBaseAddress"]; 
                Log.Info("Listening on " + baseAddress);
                // Starts OWIN host 
                using (WebApp.Start<Startup>(url: baseAddress))
                {
                    Console.ReadLine();
                }
                Log.Info("Host is being closed.");
            }
            catch (Exception exception)
            {
                Log.WriteLine(LogLevel.Fatal, "Error running service: " + exception.ToString());
                throw;
            }
        }
