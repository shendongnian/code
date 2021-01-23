    public static void Start()
    {
        var connectionThread = new Thread(StartListening);
        connectionThread.IsBackground = true;
        connectionThread.Start();
        ThreadPool.QueueUserWorkItem(Logger); //start logger thread
    }
    //thread safe data collection, can be modified from multiple threads without threading issues
    static BlockingCollection<string> logData = new BlockingCollection<string>();
    public ObservableCollection<string> Logs { get; set; } // to bind to the UI
    private void Logger(object state)
    {
        //collect everything from the logData, this loop will not terminate until `logData.CompleteAdding()` is called 
        foreach (string item in logData.GetConsumingEnumerable())
        {
            //add the item to the UI bound ObservableCollection<string>
            Dispatcher.Invoke(() => Logs.Add(item)); 
        }
    }
    private static void StartListening()
    {
        if (!isInitialized) Initialize();
        try
        {
            listener.Start();
            while (true)
            {
                client = listener.AcceptTcpClient();
                // some kind of logging here which reaches the ui immediately
                logData.TryAdd("log"); //adding a log entry to the logData, completely thread safe
                var protocol = new Protocol(client);
                var thread = new Thread(protocol.StartCommunicating) { IsBackground = true };
                thread.Start();
                connectedThreads.Add(thread);
            }
        }
        catch (Exception)
        {
            // temp
            MessageBox.Show("Error in PacketHandler class");
        }
    }
