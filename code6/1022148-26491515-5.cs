    public class RedirectProcess
    {
        public static Process StartRedirected(string filename, string args = "")
        {
            var process = Process.Start(new ProcessStartInfo
            {
                Arguments = args,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                FileName = filename
            });
            process.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
            process.BeginOutputReadLine();
            return process;
        }
        public static Process StartGrab(string filename, Action<string> dataHandle, string args = "")
        {
            var process = Process.Start(new ProcessStartInfo
            {
                Arguments = args,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                FileName = filename
            });
            process.OutputDataReceived += (s, e) => dataHandle(e.Data);
            process.BeginOutputReadLine();
            return process;
        }
    }
    public class RedirectClient:IDisposable
    {
        private readonly NetMQContext _context;
        private readonly RequestSocket _socket;
        public int Id { get; set; }
        public RedirectClient()
        {
            _context = NetMQContext.Create();
            _socket = _context.CreateRequestSocket();
            _socket.Connect("ipc://redirectCollector");
        }
        public void Send(string data)
        {
            _socket.Send(string.Format("{0},{1}", Id, data));
            _socket.Receive();//ack
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
    public class RediretServer:IDisposable
    {
        private bool _start;
        public event EventHandler<ProcessDataArgs> ProcessDataReceived;
        public RediretServer()
        {
            _start = true;
           new Thread(() =>
           {
               using (var context = NetMQContext.Create())
               {
                   var socket = context.CreateResponseSocket();
                   socket.Bind("ipc://redirectCollector");
                   while (_start)
                   {
                       var res = socket.ReceiveString(TimeSpan.FromSeconds(1));
                       if (string.IsNullOrEmpty(res))
                           continue;
                       if (ProcessDataReceived != null)
                           ProcessDataReceived(this, new ProcessDataArgs(res));
                       socket.Send(new byte[]{ });//ack
                   }
               }
           }).Start();
        }
        public void Dispose()
        {
            _start = false;
        }
    }
    public class ProcessDataArgs:EventArgs
    {
        public string Data { get;private set; }
        public int Id { get;private set; }
        public ProcessDataArgs(string result)
        {
            var i = result.IndexOf(','); //first comma
            Id = int.Parse(result.Substring(0, i));
            Data=result.Substring(i+1);
        }
    }
