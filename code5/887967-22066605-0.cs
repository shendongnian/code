        static void Main(string[] args)
        {
            string _name = Assembly.GetExecutingAssembly().Location + Guid.NewGuid().ToString();
            try
            {
                File.CreateText(_name).Close();
                File.Delete(_name);
            }
            catch (UnauthorizedAccessException)
            {
                Restart();
                return;
            }
            Console.WriteLine("execution with write access");
            Console.ReadKey();
        }
        private static void Restart()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Assembly.GetExecutingAssembly().Location;
            startInfo.Verb = "runas";
            Process p = Process.Start(startInfo);
        }
