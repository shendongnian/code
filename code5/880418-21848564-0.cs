     namespace ConsoleAppManager
        {
            using System;
            using System.Diagnostics;
            using System.Text;
            using System.Threading;
            using System.Threading.Tasks;
        
        
            /// <summary>
            /// The console app manager.
            /// </summary>
            public class ConsoleAppManager
            {
                #region Fields
        
                /// <summary>
                /// The app name.
                /// </summary>
                private readonly string appName;
        
                /// <summary>
                /// The process.
                /// </summary>
                private readonly Process process = new Process();
        
                /// <summary>
                /// The the lock.
                /// </summary>
                private readonly object theLock = new object();
        
                /// <summary>
                /// The context.
                /// </summary>
                private SynchronizationContext context;
        
                /// <summary>
                /// The pending write data.
                /// </summary>
                private string pendingWriteData;
        
                #endregion
        
                #region Constructors and Destructors
        
                /// <summary>
                /// Initializes a new instance of the <see cref="ConsoleAppManager"/> class.
                /// </summary>
                /// <param name="appName">
                /// The app name.
                /// </param>
                public ConsoleAppManager(string appName)
                {
                    this.appName = appName;
        
                    this.process.StartInfo.FileName = this.appName;
                    this.process.StartInfo.RedirectStandardError = true;
                    this.process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
        
                    this.process.StartInfo.RedirectStandardInput = true;
                    this.process.StartInfo.RedirectStandardOutput = true;
                    this.process.EnableRaisingEvents = true;
                    this.process.StartInfo.CreateNoWindow = true;
        
                    this.process.StartInfo.UseShellExecute = false;
        
                    this.process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
        
                    this.process.Exited += this.ProcessOnExited;
                }
        
                #endregion
        
                #region Public Events
        
                /// <summary>
                /// The error text received.
                /// </summary>
                public event EventHandler<string> ErrorTextReceived;
        
                /// <summary>
                /// The process exited.
                /// </summary>
                public event EventHandler ProcessExited;
        
                /// <summary>
                /// The standart text received.
                /// </summary>
                public event EventHandler<string> StandartTextReceived;
        
                #endregion
        
                #region Public Properties
        
                /// <summary>
                /// Gets the exit code.
                /// </summary>
                public int ExitCode
                {
                    get
                    {
                        return this.process.ExitCode;
                    }
                }
        
                /// <summary>
                /// Gets a value indicating whether running.
                /// </summary>
                public bool Running { get; private set; }
        
                #endregion
        
                #region Public Methods and Operators
        
                /// <summary>
                /// The execute.
                /// </summary>
                /// <param name="args">
                /// The args.
                /// </param>
                /// <exception cref="InvalidOperationException">
                /// </exception>
                public void ExecuteAsync(params string[] args)
                {
                    if (this.Running)
                    {
                        throw new InvalidOperationException(
                            "Process is still Running. Please wait for the process to complete.");
                    }
        
                    string arguments = string.Join(" ", args);
        
                    this.process.StartInfo.Arguments = arguments;
        
                    this.context = SynchronizationContext.Current;
        
                    this.process.Start();
                    this.Running = true;
        
                    new Task(this.ReadOutputAsync).Start();
                    new Task(this.WriteInputTask).Start();
                    new Task(this.ReadOutputErrorAsync).Start();
                }
        
                /// <summary>
                /// The write.
                /// </summary>
                /// <param name="data">
                /// The data.
                /// </param>
                public void Write(string data)
                {
                    if (data == null)
                    {
                        return;
                    }
        
                    lock (this.theLock)
                    {
                        this.pendingWriteData = data;
                    }
                }
        
                /// <summary>
                /// The write line.
                /// </summary>
                /// <param name="data">
                /// The data.
                /// </param>
                public void WriteLine(string data)
                {
                    this.Write(data + Environment.NewLine);
                }
        
                #endregion
        
                #region Methods
        
                /// <summary>
                /// The on error text received.
                /// </summary>
                /// <param name="e">
                /// The e.
                /// </param>
                protected virtual void OnErrorTextReceived(string e)
                {
                    EventHandler<string> handler = this.ErrorTextReceived;
        
                    if (handler != null)
                    {
                        if (this.context != null)
                        {
                            this.context.Post(delegate { handler(this, e); }, null);
                        }
                        else
                        {
                            handler(this, e);
                        }
                    }
                }
        
                /// <summary>
                /// The on process exited.
                /// </summary>
                protected virtual void OnProcessExited()
                {
                    EventHandler handler = this.ProcessExited;
                    if (handler != null)
                    {
                        handler(this, EventArgs.Empty);
                    }
                }
        
                /// <summary>
                /// The on standart text received.
                /// </summary>
                /// <param name="e">
                /// The e.
                /// </param>
                protected virtual void OnStandartTextReceived(string e)
                {
                    EventHandler<string> handler = this.StandartTextReceived;
        
                    if (handler != null)
                    {
                        if (this.context != null)
                        {
                            this.context.Post(delegate { handler(this, e); }, null);
                        }
                        else
                        {
                            handler(this, e);
                        }
                    }
                }
        
                /// <summary>
                /// The process on exited.
                /// </summary>
                /// <param name="sender">
                /// The sender.
                /// </param>
                /// <param name="eventArgs">
                /// The event args.
                /// </param>
                private void ProcessOnExited(object sender, EventArgs eventArgs)
                {
                    this.OnProcessExited();
                }
        
                /// <summary>
                /// The read output async.
                /// </summary>
                private async void ReadOutputAsync()
                {
                    var standart = new StringBuilder();
                    var buff = new char[1024];
                    int length;
        
                    while (this.process.HasExited == false)
                    {
                        standart.Clear();
        
                        length = await this.process.StandardOutput.ReadAsync(buff, 0, buff.Length);
                        standart.Append(buff.SubArray(0, length));
                        this.OnStandartTextReceived(standart.ToString());
                        Thread.Sleep(1);
                    }
        
                    this.Running = false;
                }
        
                /// <summary>
                /// The read output error async.
                /// </summary>
                private async void ReadOutputErrorAsync()
                {
                    var sb = new StringBuilder();
        
                    do
                    {
                        sb.Clear();
                        var buff = new char[1024];
                        int length = await this.process.StandardError.ReadAsync(buff, 0, buff.Length);
                        sb.Append(buff.SubArray(0, length));
                        this.OnErrorTextReceived(sb.ToString());
                        Thread.Sleep(1);
                    }
                    while (this.process.HasExited == false);
                }
        
                /// <summary>
                /// The write input task.
                /// </summary>
                private async void WriteInputTask()
                {
                    while (this.process.HasExited == false)
                    {
                        Thread.Sleep(1);
        
                        if (this.pendingWriteData != null)
                        {
                            await this.process.StandardInput.WriteLineAsync(this.pendingWriteData);
                            await this.process.StandardInput.FlushAsync();
        
                            lock (this.theLock)
                            {
                                this.pendingWriteData = null;
                            }
                        }
                    }
                }
        
                #endregion
            }
        }
