    public partial class SillyControl : UserControl
    {
        Thread backgroundThread;
        Service service = new Service();
        public SillyControl()
        {
            InitializeComponent();
            this.Disposed += delegate { Trace.WriteLine("I been disposed!"); };
            backgroundThread = new Thread(argument =>
            {
                Trace.WriteLine("Background ping thread has started.");
                while (true)
                {
                    Thread.Sleep(5000);
                    try
                    {
                        service.Ping();
                        Trace.WriteLine("Ping!");
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(string.Format("Ping failed: {0}", ex.Message)); 
                    }
                }
            });
            backgroundThread.IsBackground = true; // <- Important! You don't want this thread to keep the application open.
            backgroundThread.Start();
        }
    }
