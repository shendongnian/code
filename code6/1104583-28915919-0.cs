        static void Main(string[] args)
        {
            var p = Process.GetProcesses();
            foreach (var process in p)
            {
                try
                {
                    // you can add the process to your process list, chack existence and etc...
                    process.EnableRaisingEvents = true;
                    process.Exited += Program_Exited;
                }
                catch (Exception)
                {
                    //any process that you don't have credantial will throw exception...
                }
            }
            Console.ReadLine();
        }
        private static void Program_Exited(object sender, EventArgs e)
        {
            var process = (Process) sender;
            var startTime = process.StartTime;
            var endTime = process.ExitTime;
            
        }
