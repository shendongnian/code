    void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
    	int iMaxWaitMSec = 10000;
    	if (mut.WaitOne(iMaxWaitMSec))
    	{
    		try
    		{
    			// Populate DataTable
    		}
    		catch
    		{
    		}
    		finally
    		{
    			mut.ReleaseMutex();
    		}
    	}
    	else
    	{
    		// we waited longer than iMaxWaitMSec milliseconds
            // in an attempt to lock the mutex
    		// skip this timer event
    		// we'll retry next time
    	}
    }
.
    void timer2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
    	int iMaxWaitMSec = 10000;
    	if (mut.WaitOne(iMaxWaitMSec))
    	{
    		try
    		{
    			// Send DataTable to the database
    		}
    		catch
    		{
    		}
    		finally
    		{
    			mut.ReleaseMutex();
    		}
    	}
    	else
    	{
    		// we waited longer than iMaxWaitMSec milliseconds
            // in an attempt to lock the mutex
    		// skip this timer event
    		// we'll retry next time
    	}
    }
