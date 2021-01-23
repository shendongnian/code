    class EventListener
    {
    	public EventPublisher publisher = new EventPublisher();
    	
    	public EventListener()
    	{
    		publisher.Event += HandleEvent;
    	}
    	
    	void HandleEvent(object sender, EventArgs e)
    	{
    	}
    }
    
    class EventPublisher
    {
    	EventHandler _event;	
    	public event EventHandler Event
    	{
    		add { _event += value; }
    		remove { _event -= value; }
    	}
    	
    	public List<EventListener> GetListeners()
    	{
    		return _event.GetInvocationList().Select(i => i.Target).OfType<EventListener>().ToList();
    	}
    }
