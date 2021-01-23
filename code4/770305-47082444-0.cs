    public class Program
    {
        private static Dictionary<string, MyProcess> _processes;
        private static void Main()
        {
            // can store this to file or db
            var processId = Guid.NewGuid().ToString();
            var myProcess = new MyProcess
            {
                StartInfo = { FileName = @"C:\HelloWorld.exe" },
                ProcessId = processId
            };
            _processes = new Dictionary<string, MyProcess> {{processId, myProcess}};
            myProcess.Start();
            Thread.Sleep(5000);
            // read id from file or db or another
            var pr = _processes[processId];
            pr.Kill();
            Console.ReadKey();
        }
    }
    public class MyProcess : Process
    {
        public string ProcessId { get; set; }
    }
