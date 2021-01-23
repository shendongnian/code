    while(true)
    {
       if (continueDispatcher)
       {
	       Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
	       {
		       numDone = DoStuff();
	       }
       }
       Thread.Sleep(50);
    }
