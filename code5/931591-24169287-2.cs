    //HandleTime is inside the new thread
    private void HandleTime()
    {
    	Stopwatch threadStopwatch = new Stopwatch();
    	TimeSpan timespan;
    	threadStopwatch.Start();
    	while (this.isThreadRunning)
    	{
			timespan = threadStopwatch.Elapsed;
            //using invoke to update the label which is in the original thread 
            //and avoid a cross thread exception
			if (this.InvokeRequired)
                {
                    //read up on lamda functions if you don't know what this is doing
                    this.Invoke(new MethodInvoker(() => 
                        label1.Text = timespan.Minutes + " : " + timespan.Seconds + " : " + timespan.Milliseconds
                        ));
                }
                else
                {
                    label1.Text = timespan.Minutes + " : " + timespan.Seconds + " : " + timespan.Milliseconds;
                }
	    }
    }
