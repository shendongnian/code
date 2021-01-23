    public class TimeoutInvoker
    {
        public static TResult Run<TResult>(Func<TResult> action, int timeout)
        {
    		var task = Task.Factory.StartNew(action);
    		
    		if (task.Wait(timeout)) 
    			return task.Result;
    			
            throw new TimeoutException("Timeout.");
        }
    }
