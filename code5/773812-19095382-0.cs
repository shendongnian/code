    private void InitTimer()
{
	double lInterval = Convert.ToDouble(AppSettings("MaxExecutionTime"));
	lInterval = lInterval * 60 * 1000;
	tm = new System.Timers.Timer(lInterval); // global timer object
	tm.Elapsed += OnTimedEvent;
	tm.Enabled = true;
