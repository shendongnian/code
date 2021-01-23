    public class NullAsyncResult : IAsyncResult
    {
    public object AsyncState
    {
    get { return null; }
    }
    
    public System.Threading.WaitHandle AsyncWaitHandle
    {
    get { return null; }
    }
    
    public bool CompletedSynchronously
    {
    get { return true; }
    }
    
    public bool IsCompleted
    {
    get { return true; }
    }
    }
