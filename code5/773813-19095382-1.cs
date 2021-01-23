	private void InitTimer()
	{
		double lInterval = Convert.ToDouble(AppSettings("MaxExecutionTime"));
		lInterval = lInterval * 60 * 1000;
		tm = new System.Timers.Timer(lInterval); // global timer object
		tm.Elapsed += OnTimedEvent;
		tm.Enabled = true;
	}
	public void ThreadProc(object stateinfo)
	{
		// set error code here
		Environment.Exit(0);
	}
	private void OnTimedEvent(object source, ElapsedEventArgs e)
	{
	   Threading.ThreadPool.QueueUserWorkItem(new Threading.WaitCallback(ThreadProc));
	}
