    public class TimeoutInvoker
    {
        public static TResult Run<TResult>(Func<TResult> action, int timeout)
        {
            var waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
            AsyncCallback callback = ar => waitHandle.Set();
    		IAsyncResult result = action.BeginInvoke(callback, null);
    		
            if (!waitHandle.WaitOne(timeout))
                throw new TimeoutException("Timeout.");
    			
    		return action.EndInvoke(result);
        }
    }
