    static void Main(string[] args)
    {
        string serviceToRun = "WebClient";
        using (ServiceController serviceController = new ServiceController(serviceToRun))
        {
            Console.WriteLine(string.Format("Current Status of {0}: {1}", serviceToRun, serviceController.Status));
            if (serviceController.Status == ServiceControllerStatus.Stopped)
            {
                Console.WriteLine(string.Format("Starting {0}", serviceToRun));
                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 20));
                Console.WriteLine(string.Format("{0} {1}", serviceToRun, serviceController.Status));
            }
        }
        Console.ReadLine();
    }
