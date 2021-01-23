    int opsLeft = data.Count();
    using (var mre = new ManualResetEvent(false))
    {
    	foreach (DataRow row in data)
    	{
    		string refId = Convert.ToString(row["ReferenceID"]);
    		if (!string.IsNullOrEmpty(refId))
    		{
    			ThreadPool.QueueUserWorkItem(_ =>
    			{
    				apeDBAdapter.SendEmail(personId, refId, parentReferenceID, customerName, queueId);
    				if (Interlocked.Decrement(ref opsLeft) == 0)
    					mre.Set();
    			});
    		}
    		else
    		{
    			if (Interlocked.Decrement(ref opsLeft) == 0)
    				mre.Set();
    		}
    	}
    	mre.WaitOne();
    }
