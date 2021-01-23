    static void Main()
        {
            JobHostConfiguration config = new JobHostConfiguration();
            config.UseTimers();
            var host = new JobHost(config);
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
