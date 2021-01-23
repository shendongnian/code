    // System.Data.SqlClient.SqlTransaction
    protected override void Dispose(bool disposing)
    {
    	if (disposing)
    	{
    		SNIHandle target = null;
    		RuntimeHelpers.PrepareConstrainedRegions();
    		try
    		{
    			target = SqlInternalConnection.GetBestEffortCleanupTarget(this._connection);
    			if (!this.IsZombied && !this.IsYukonPartialZombie)
    			{
    				this._internalTransaction.Dispose();
    			}
    		}
    		catch (OutOfMemoryException e)
    		{
    			this._connection.Abort(e);
    			throw;
    		}
    		catch (StackOverflowException e2)
    		{
    			this._connection.Abort(e2);
    			throw;
    		}
    		catch (ThreadAbortException e3)
    		{
    			this._connection.Abort(e3);
    			SqlInternalConnection.BestEffortCleanup(target);
    			throw;
    		}
    	}
    	base.Dispose(disposing);
    }
