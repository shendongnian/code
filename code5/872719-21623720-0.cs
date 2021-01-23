    class Program
    {
        static void Main(string[] args)
        {
            var net = new Process()
            {
                StartInfo = new ProcessStartInfo("net.exe", @"view /domain:domain")
                {
                    RedirectStandardOutput =  true,
                    UseShellExecute = false,
                },
              
            
            };
            net.OutputDataReceived += WriteToConsole;
            net.ErrorDataReceived += WriteToConsole;
            net.Start();
            net.BeginOutputReadLine();
            net.WaitForExit();
            Console.ReadLine();
        }
        private static void WriteToConsole(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }
    }
