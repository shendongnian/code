    public class ProcessExitedEventArgs<TKey> : EventArgs
    {
        public ProcessExitedEventArgs(TKey key, string[] output)
        {
            this.Key = key;
            this.Output = output;
        }
        public TKey Key { get; private set; }
        public string[] Output { get; private set; }
    }
    public delegate void ProcessExitedEventHandler<TKey>(object sender, ProcessExitedEventArgs<TKey> e);
    public class ProcessLauncher<TKey>
    {
        public string FileName { get; private set; }
        public string Arguments { get; private set; }
        public TKey Key { get; private set; }
        object locker = new object();
        readonly List<string> output = new List<string>();
        Process process = null;
        bool launched = false;
        public ProcessLauncher(string fileName, string arguments, TKey key)
        {
            this.FileName = fileName;
            this.Arguments = arguments;
            this.Key = key;
        }
        public event ProcessExitedEventHandler<TKey> Exited;
        public bool Start()
        {
            lock (locker)
            {
                if (launched)
                    throw new InvalidOperationException();
                launched = true;
                process = new Process();
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.ErrorDialog = false;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(proc_Exited);
                process.OutputDataReceived += proc_OutputDataReceived;
                process.ErrorDataReceived += proc_ErrorDataReceived;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = FileName;
                process.StartInfo.Arguments = Arguments;
                try
                {
                    var started = process.Start();
                    process.BeginErrorReadLine();
                    process.BeginOutputReadLine();
                    return started;
                }
                catch (Exception)
                {
                    process.Dispose();
                    process = null;
                    throw;
                }
            }
        }
        void proc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Fill in as appropriate.
            Debug.WriteLine("Error data received");
        }
        void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null)
                return;
            lock (locker)
            {
                output.Add(e.Data);
            }
        }
        void proc_Exited(object sender, EventArgs e)
        {
            lock (locker)
            {
                var exited = Exited;
                if (exited != null)
                {
                    exited(this, new ProcessExitedEventArgs<TKey>(Key, output.ToArray()));
                    // Prevent memory leaks by removing references to listeners.
                    Exited -= exited;
                }
            }
            var process = Interlocked.Exchange(ref this.process, null);
            if (process != null)
            {
                process.OutputDataReceived -= proc_OutputDataReceived;
                process.ErrorDataReceived -= proc_ErrorDataReceived;
                process.Exited -= proc_Exited;
                process.Dispose();
            }
        }
    }
