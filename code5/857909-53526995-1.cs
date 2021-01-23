    using System.Threading;
    System.Threading.Timer timer = new System.Threading.Timer(timerC, null, 5000, 5000);
    private void timerC(object state)
	{
		Environment.Exit(0);
	}
