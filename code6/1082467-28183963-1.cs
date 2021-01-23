	[TestMethod, Timeout(5000)]
	public void TestMethod1()
	{
		var testManagementService = new ManagementService();
		AutoResetEvent evt = new AutoResetEvent(false);
		testManagementService.SomethingHappened += delegate (System.Object o, System.EventArgs e)
		{
			evt.Set();
		};
		var vm = new ViewModel(testManagementService);
		evt.WaitOne();
	}
