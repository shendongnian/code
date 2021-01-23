    // wait for a handle while dispatching messages with Application.DoEvents
    public static bool WaitWithDoEvents(WaitHandle handle, int timeout)
    {
    	var currentTimeout = timeout;
    
    	// track timeout if not infinite
    	Func<bool> hasTimedOut = null;
    	if (timeout != Timeout.Infinite)
    	{
    		// can't use Environment.TickCount as it is int, problems with wrapping
    		uint startTick = Win32.GetTickCount();
    		hasTimedOut = () =>
    		{
    			var lapse = (int)(unchecked(Win32.GetTickCount() - startTick));
    			currentTimeout = timeout - lapse;
    			return currentTimeout <= 0;
    		};
    	}
    	else
    	{
    		hasTimedOut = () => false;
    	}
    
    	IntPtr[] handles = { handle.SafeWaitHandle.DangerousGetHandle() };
    
    	while (true)
    	{
    		// process any pending messages
    		while ((Win32.GetQueueStatus(Win32.QS_ALL) & Win32.QS_ALL) != 0) // low word is non-zero if input/message pending
    		{
    			if (handle.WaitOne(0))
    				return true;
    			var autoInstall = System.Windows.Forms.WindowsFormsSynchronizationContext.AutoInstall;
    			try
    			{
    				// http://goo.gl/V0mdYj
    				System.Windows.Forms.WindowsFormsSynchronizationContext.AutoInstall = false;
    				System.Windows.Forms.Application.DoEvents();
    			}
    			finally
    			{
    				System.Windows.Forms.WindowsFormsSynchronizationContext.AutoInstall = autoInstall;
    			}
    			if (hasTimedOut())
    				return false;
    		}
    		// wait for either a message or the handle
    		var result = Win32.MsgWaitForMultipleObjects(1, handles, false, (uint)currentTimeout, Win32.QS_ALL);
    		if (result == Win32.WAIT_OBJECT_0)
    			return true;
    		if (result == Win32.WAIT_TIMEOUT)
    			return false;
    	}
    }
