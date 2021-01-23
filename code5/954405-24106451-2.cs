    /// <summary>
    /// Represents the ProcessOutputReader class.
    /// </summary>
    public class ProcessOutputReader
    {
        /// <summary>
        /// Represents the instance of the thread arguments class.
        /// </summary>
        private ProcessOutputReaderWorkerThreadArguments threadArguments;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessOutputReader"/> class.
        /// </summary>
        /// <param name="process">The process which's output shall be read.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Is thrown if the specified process reference is null.</exception>
        public ProcessOutputReader(Process process)
        {
            if (process == null)
            {
                throw new ArgumentOutOfRangeException("process", "The parameter \"process\" must not be null");
            }
            this.Process = process;
            this.IntermediateDataStore = new StringBuilder();
            this.threadArguments = new ProcessOutputReaderWorkerThreadArguments(this.Process, this.IntermediateDataStore);
        }
        /// <summary>
        /// Is fired whenever data has been read from the process output.
        /// </summary>
        public event EventHandler<ProcessOutputReaderEventArgs> OnDataRead;
        /// <summary>
        /// Gets or sets the worker thread.
        /// </summary>
        private Thread ReaderThread
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the intermediate data store.
        /// </summary>
        private StringBuilder IntermediateDataStore
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the data collected from the process output.
        /// </summary>
        public string Data
        {
            get
            {
                return this.IntermediateDataStore.ToString();
            }
        }
        /// <summary>
        /// Gets the process.
        /// </summary>
        public Process Process
        {
            get;
            private set;
        }
        /// <summary>
        /// Stars reading from the process output.
        /// </summary>
        public void StartReading()
        {
            if (this.ReaderThread != null)
            {
                if (this.ReaderThread.IsAlive)
                {
                    return;
                }
            }
            this.ReaderThread = new Thread(new ParameterizedThreadStart(ReaderWorker));
            this.threadArguments.Exit = false;
            this.ReaderThread.Start(this.threadArguments);
        }
        /// <summary>
        /// Stops reading from the process output.
        /// </summary>
        public void StopReading()
        {
            if (this.ReaderThread != null)
            {
                if (this.ReaderThread.IsAlive)
                {
                    this.threadArguments.Exit = true;
                    this.ReaderThread.Join();
                }
            }
        }
        /// <summary>
        /// Fires the OnDataRead event.
        /// </summary>
        /// <param name="newData">The new data that has been read.</param>
        protected void FireOnDataRead(string newData)
        {
            if (this.OnDataRead != null)
            {
                this.OnDataRead(this, new ProcessOutputReaderEventArgs(this.IntermediateDataStore, newData));
            }
        }
        /// <summary>
        /// Represents the worker method.
        /// </summary>
        /// <param name="data">The thread arguments, must be an instance of the <see cref="ProcessOutputReaderWorkerThreadArguments"/> class.</param>
        private void ReaderWorker(object data)
        {
            ProcessOutputReaderWorkerThreadArguments args;
            try
            {
                args = (ProcessOutputReaderWorkerThreadArguments)data;
            }
            catch
            {
                return;
            }
            try
            {
                char[] readBuffer = new char[args.ReadBufferSize];
                while (!args.Exit)
                {
                    if (args.Process == null)
                    {
                        return;
                    }
                    if (args.Process.HasExited)
                    {
                        return;
                    }
                    if (args.Process.StandardOutput.EndOfStream)
                    {
                        return;
                    }
                    int readBytes = this.Process.StandardOutput.Read(readBuffer, 0, readBuffer.Length);
                    args.IntermediateDataStore.Append(readBuffer, 0, readBytes);
                    this.FireOnDataRead(new String(readBuffer, 0, readBytes));
                }
            }
            catch (ThreadAbortException)
            {
                if (!args.Process.HasExited)
                {
                    args.Process.Kill();
                }
            }
        }
    }
