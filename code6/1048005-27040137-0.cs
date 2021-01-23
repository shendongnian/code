    Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
    {
	    while(true)
	    {
	       if (continueDispatcher)
		       numDone = DoStuff();
	       Application.DoEvents();
	    }
    }
