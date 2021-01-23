    public class ProcessOutputReader
    {
        public ProcessOutputReader(Process process)
        {
            this.Process = process;
        }
        public List<string> Lines
        {
            get;
            private set;
        }
        public Process Process
        {
            get;
            private set;
        }
        private Thread ReaderThread
        {
            get;
            set;
        }
        public void StartReading()
        {
            if (this.ReaderThread == null)
            {
                this.ReaderThread = new Thread(new ThreadStart(ReaderWorker));
            }
            if (!this.ReaderThread.IsAlive)
            {
                this.ReaderThread.Start();
            }
        }
        public void StopReading()
        {
            if (this.ReaderThread != null)
            {
                if (this.ReaderThread.IsAlive)
                {
                    this.ReaderThread.Abort();
                    this.ReaderThread.Join();
                }
            }
        }
        private void ReaderWorker()
        {
            try
            {
                while (!this.Process.HasExited)
                {
                    string data = this.Process.StandardOutput.ReadLine();
                    this.Lines.Add(data);
                }
            }
            catch (ThreadAbortException)
            {
                if (!this.Process.HasExited)
                {
                    this.Process.Kill();
                }
            }
        }
    }
