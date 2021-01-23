    public class TimeoutInvoker
    {
        public static void Run(Action action, int timeout)
        {
            var waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
            AsyncCallback callback = ar => waitHandle.Set();
            action.BeginInvoke(callback, null);
            if (!waitHandle.WaitOne(timeout))
                throw new TimeoutException("Timeout.");
        }
    }
