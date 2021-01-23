    private static void Main(string[] args)
        {
            if (IsApplicationAlreadyRunning())
            {
                Console.Write("The application is already running");
            }
            else
            {
                Console.Write("The application is not running");
            }
            Console.Read();
        }
         static bool IsApplicationAlreadyRunning()
        {
            return Process.GetProcesses().Count(p => p.ProcessName.Contains(Assembly.GetExecutingAssembly().FullName.Split(',')[0]) && !p.Modules[0].FileName.Contains("vshost")) > 1;
        }
