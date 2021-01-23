    class Processor : IProcessorFacade
    {
    	private readonly Dictionary<Type, Action<object>> handlers;
    
    	public Processor()
    	{
    		this.handlers = new Dictionary<Type, Action<object>>();
    
    		this.AddHandler<One>(item => Console.WriteLine("Item One has been processed"));
    		this.AddHandler<Two>(item => Console.WriteLine("Item Two has been processed"));
    		this.AddHandler<Three>(item => Console.WriteLine("Item Three has been processed"));
    	}
    
    	public void AddHandler<T>(Action<T> handler)
    	{
    		this.handlers[typeof(T)] = item => handler((T)item);
    	}
    
    	public void Process<T>(T item)
    	{
    		Action<object> handler;
    		if (this.handlers.TryGetValue(typeof(T), out handler))
    			handler(item);
    		else
    			throw new InvalidOperationException(String.Format("Handler for type {0} has not been set", typeof(T)));
    	}
    }
