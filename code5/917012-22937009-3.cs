     private void test1(object obj)
    {
	if ((obj) is ManualResetEvent) {
		dynamic _wait = (ManualResetEvent)obj;
		Thread.Sleep(5000);
		_wait.Set();
	}
    }
    private void TestT_Load(System.Object sender, System.EventArgs e)
    {
	Interaction.MsgBox("Operation started at " + DateAndTime.Now);
	List<ManualResetEvent> h = new List<ManualResetEvent>();
	ManualResetEvent _wait = new ManualResetEvent(false);
	h.Add(_wait);
	ThreadPool.QueueUserWorkItem(new WaitCallback(test1), _wait);
	WaitHandle.WaitAll(h.ToArray());
	Interaction.MsgBox("Operation completed at " + DateAndTime.Now);
    }
