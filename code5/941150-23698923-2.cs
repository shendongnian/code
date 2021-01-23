    public class MessageProcessor
    {
    	private IDictionary<Type, IMessageHandler> _messageHandlers = 
    		new Dictionary<Type, IMessageHandler>();
    		
    	public void AddHandler<TMessage>(IMessageHandler handler)
        {
    		//omitted error checking etc for brevity
    		_messageHandlers.Add(handler.Handles, handler);
        }
    
        public void Handle<TMessage>(TMessage message)
        {
    		//omitted error checking etc for brevity
    		var handler = _messageHandlers[typeof(message)];
        }
    }
