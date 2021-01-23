    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Contains("--service", StringComparer.OrdinalIgnoreCase))
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new Service1()
                };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                Thread formsThread = new Thread(FormsMain);
                formsThread.IsBackground = false;
                formsThread.SetApartmentState(ApartmentState.STA);
                formsThread.Name = "New Main";
                formsThread.Start();
                //The program will continue on here and exit Main but the program 
                // will not shutdown because formsThread is not a background thread.
            }
        }
        
        static void FormsMain()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
