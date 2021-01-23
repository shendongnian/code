    while (operation)
    {
		int pendingOperations = 0;
		// ... Do work
		// Update, but only if there isn't a pending update
		if (0 == Interlocked.CompareExchange(ref pendingOperations, 1, 0))
		{
			control.BeginInvoke(new Action( () =>
			{	
				// Update gauges
				// Restore, so the next UI update can occur
				Interlocked.Decrement(ref pendingOperations);
            }));
		}       
    }
    // Update at the end (since you're last update might have been skipped)
    control.Invoke(new Action(UpdateGuagesCompleted));
