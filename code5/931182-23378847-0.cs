    public MainWindow()
    {
        InitializeComponent();
                
    	//A local variable
    	var logRecords = new ObservableList<LogRecord>();
        DataContext = this;
        new Thread(() =>
        {
            LogRecord record = new LogRecord();
            record.Message = "Hello, world.";
            record.Timestamp = DateTime.Now;
            List<LogRecord> logRecordList = new List<LogRecord>();
            for (int i = 0; i < 1000000; i++)
            {
                logRecordList.Add(record);
            }
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Dispatcher.Invoke(() =>
            {
    			// Should prevent UI to update itself
                logRecords .AddRange(logRecordList);
            });
            timer.Stop();
        	
    		// Assign to actual collection causing UI update
    		LogRecords = logRecords ;    
    		Console.WriteLine("The operation took {0} milliseconds.", timer.ElapsedMilliseconds);
    
    	}).Start();
    }
