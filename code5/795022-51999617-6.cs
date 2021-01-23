    public static class SafeExecute
    {
    	public static void Invoke(Action tryBlock, Action finallyBlock, Action onSuccess = null, Action<Exception> onError = null)
    	{
    		Exception tryException = null;
    
    		try
    		{
    			tryBlock?.Invoke();
    		}
    		catch (Exception ex)
    		{
    			tryException = ex;
    			throw;
    		}
    		finally
    		{
    			try
    			{
    				finallyBlock?.Invoke();
    				onSuccess?.Invoke();
    			}
    			catch (Exception ex)
    			{
    				onError?.Invoke(ex);
    
    				// don't override the original exception! Thus throwing a new AggregateException containing both exceptions.
    				if (tryException != null)
    					throw new AggregateException(tryException, ex);
    
    				// otherwise re-throw the exception from the finally block.
    				throw;
    			}
    		}
    	}
    }
