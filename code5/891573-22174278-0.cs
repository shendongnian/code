    public class Task : IAsyncResult
    {
        WaitHandle IAsyncResult.AsyncWaitHandle
        {
            get { ... }
        }
    }
