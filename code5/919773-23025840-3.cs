    public class AsyncData<T>
    {
    	readonly Lazy<Task<T>> _data;
    
    	// expose sync initializer as async
    	public AsyncData(Func<Task<T>> asyncInit, bool makeThreadSafe = true)
    	{
    		_data = new Lazy<Task<T>>(asyncInit, makeThreadSafe);
    	}
    
    	// expose async initializer 
    	public AsyncData(Func<T> syncInit, bool makeThreadSafe = true)
    	{
    		_data = new Lazy<Task<T>>(() => 
    		    Task.FromResult(syncInit()), makeThreadSafe);
    	}
    
    	public Task<T> AsyncValue
    	{
    		get { return _data.Value; }
    	}
    }
