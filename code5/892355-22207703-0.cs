    void Main()
    {
    	using(var mq = new MessageQueue())
    	{
    		var m1 = new Message((m)=>{
    			Console.WriteLine("a");
    		});
    		var m2 = new Message((m)=>{
    			Console.WriteLine("b");
    		});
    		
    		mq.QueueMessage(m1);
    		mq.QueueMessage(m2);
    		
    		var r = new Random();
    		
    		while(mq.StillWaiting)
    		{
    			Thread.Sleep(1);
    			var rnum = r.Next(0,100);
    			if(rnum > 75)
    			{
    				var nm = mq.NextMessage;
    				if(nm != null)
    					mq.ResponseReceived(nm.messageId);
    			}
    		}
    	}
    }
    
    // Define other methods and classes here
    
    public class MessageQueue : IDisposable{
    	public List<Message> Messages {get;set;}
    	
    	public bool StillWaiting {
    		get{
    			lock(Messages)
    				return Messages.Count > 0;
    		}
    	}
    	
    	public Message NextMessage{
    		get{
    			lock(Messages)
    				return Messages.FirstOrDefault();
    		}
    	}
    	
    	private Timer _sendTimer;
    	private List<Guid> responses;
    	
    	public MessageQueue()
    	{
    		Messages = new List<Message>();
    		responses = new List<Guid>();
    		_sendTimer = new Timer(timerTick,this,10,10);
    	}
    	
    	public void ResponseReceived(Guid id)
    	{
    		lock(Messages)
    		{
    			if(responses.Contains(id) == false)
    				responses.Add(id);
    		}
    	}
    	
    	public void QueueMessage(Message m)
    	{
    		lock(Messages)
    			Messages.Add(m);
    	}
    	
    	public void timerTick(object state)
    	{
    		lock(Messages)
    		{
    			foreach(var m in Messages.ToArray())
    			{
    				Console.WriteLine("Checking " + m.messageId);
    				if(m.SendCount == 0 || responses.Contains(m.messageId) == false)
    				{
    					m.Send();
    					return;
    				}
    				Console.WriteLine("Got response from " + m.messageId);
    				Messages.Remove(m);
    				responses.Remove(m.messageId);
    			}
    		}
    	}
    	
    	public void Dispose()
    	{
    		_sendTimer.Dispose();
    	}
    }
    
    public class Message
    {
    	public Guid messageId;
    	public int SendCount {get;private set;}
    	private Action<Message> sendAction;
    	public Message(Action<Message> a)
    	{
    		SendCount = 0;
    		messageId = Guid.NewGuid();
    		sendAction = a;
    	}
    	
    	public void Send()
    	{
    		sendAction.Invoke(this);
    		SendCount++;
    	}
    }
