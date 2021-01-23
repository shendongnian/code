    class Program
    {
        private static Socket _pub;
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                _pub = context.Socket(SocketType.PUB);
                _pub.Bind("tcp://*:2550");
                StartXyz();
                Console.WriteLine("Press any key to close middle process...");
                Console.ReadKey();
            }
        }
        private static void StartXyz()
        {
             var serverProcess = Process.Start(new ProcessStartInfo
            {
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory,
                Arguments = string.Empty,
                FileName = "XYZ.exe",
                UseShellExecute = false
            });
            serverProcess.OutputDataReceived += serverProcess_OutputDataReceived;
            serverProcess.ErrorDataReceived += serverProcess_OutputDataReceived;
            serverProcess.BeginOutputReadLine();
            serverProcess.BeginErrorReadLine();
        }
        private static void serverProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            _pub.Send(e.Data, Encoding.UTF8);
            Console.WriteLine(e.Data + " pushed.");
        }
    }
