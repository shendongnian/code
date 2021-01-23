    public class Parser 
    {
    	private Dictionary<string, Func<Message, string>> _handlers = 
                                   new Dictionary<string, Func<Message, string>>
    	{
    		{"Tag1", (message) => {here are parse rules}},
    		{"Tag2", (message) => {here are parse rules2}},
    	}
    	
    	public string Handle(Message message)
    	{
    		var handler = _handlers[message.Tag];
    		return handler(message);
    	}
    }
