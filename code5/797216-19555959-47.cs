    /// <summary>
    /// AwaitHelpers - custom awaiters
    /// WithContext continues on the control's thread after await
    /// E.g.: await TaskEx.Delay(1000).WithContext(this)
    /// </summary>
    public static class AwaitHelpers
    {
    	public static ContextAwaiter<T> WithContext<T>(this Task<T> task, Control control, bool alwaysAsync = false)
    	{
    		return new ContextAwaiter<T>(task, control, alwaysAsync);
    	}
    
    	// ContextAwaiter<T>
    	public class ContextAwaiter<T> : INotifyCompletion
    	{
    		readonly Control _control;
    		readonly TaskAwaiter<T> _awaiter;
    		readonly bool _alwaysAsync;
    
    		public ContextAwaiter(Task<T> task, Control control, bool alwaysAsync)
    		{
    			_awaiter = task.GetAwaiter();
    			_control = control;
    			_alwaysAsync = alwaysAsync;
    		}
    
    		public ContextAwaiter<T> GetAwaiter() { return this; }
    
    		public bool IsCompleted { get { return !_alwaysAsync && _awaiter.IsCompleted; } }
    
    		public void OnCompleted(Action continuation)
    		{
    			if (_alwaysAsync || _control.InvokeRequired)
    			{
    				Action<Action> callback = (c) => _awaiter.OnCompleted(c);
    				_control.BeginInvoke(callback, continuation);
    			}
    			else
    				_awaiter.OnCompleted(continuation);
    		}
    
    		public T GetResult()
    		{
    			return _awaiter.GetResult();
    		}
    	}
    }
