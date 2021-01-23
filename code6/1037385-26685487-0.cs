    class EventManager {
    	public Dictionary<Type, ICollection<EventHandler>> 
            HandlerMap = new Dictionary<Type, ICollection<EventHandler>>();
    	
    	public void RegisterEventHandler<TEvent>(EventHandler eh) 
            where TEvent: SomeEventType 
        {
    		Type eventType = typeof(TEvent);
    		
    		if (!HandlerMap.ContainsKey(eventType)) {
    			HandlerMap[eventType] = new List<EventHandler>();
    		}
    		
    		HandlerMap[eventType].Add(eh);
    	}
    }
