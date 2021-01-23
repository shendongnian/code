    namespace ThreadExceptions
    {
    	using System;
    	using System.Threading;
    	using System.Threading.Tasks;
    
    	public static class TaskExtensions
    	{
    		public static Task ObserveExceptions(this Task task)
    		{
    			return task.ContinueWith((t) =>
    			{
    				ThreadPool.QueueUserWorkItem((w) =>
    				{
    					if (t.Exception != null)
    					{
    						foreach (Exception ex in t.Exception.InnerExceptions)
    						{
    							throw new TaskException(ex);
    						}
    					}
    				});
    			}, TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.PreferFairness);
    		}
    	}
    }
