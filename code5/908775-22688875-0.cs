        public class MessageQueue
	{
	    public Queue<Message> MessageWorkItem { get; set; }
	    public MessageQueue()
	    {
	        MessageWorkItem = new Queue<Message>();
	    }
	    public Message GetMessageMetaData()
	    {
	        try
	        {
	            // It is just a test, add only one item into the queue
	            return new Message()
	            {
	                MessageID = Guid.NewGuid(),
	                NumberToCall = "1111111111",
	                FacilityID = "3333",
	                NumberToDial = "2222222222",
	                CountryCode = "1",
	                Acknowledge = false
	            };
	        }
	        catch (Exception ex)
	        {
	            return null;
	        }
	    }
	    public void AddingItemToQueue()
	    {
	        var message = GetMessageMetaData();
	        if (!message.Acknowledge)
	        {
	            lock (MessageWorkItem)
	            {
	                MessageWorkItem.Enqueue(message);
	            }
	        }
	    }
	}
	public class Message
	{
	    public Guid MessageID { get; set; }
	    public string NumberToCall { get; set; }
	    public string FacilityID { get; set; }
	    public string NumberToDial { get; set; }
	    public string CountryCode { get; set; }
	    public bool Acknowledge { get; set; }
	}
	class Program
	{
	    static void Main(string[] args)
	    {
	        MessageQueue me = new MessageQueue();
	        for (int i = 0; i < 10000; i++)
	            me.AddingItemToQueue();
	        Console.WriteLine(me.MessageWorkItem.Count);
	        Parallel.ForEach(me.MessageWorkItem, RunScript);
	    }
	    static void RunScript(Message item)
	    {
	        // todo: ...
	        Console.WriteLine(item.MessageID);
	        Thread.Sleep(300);
	    }
	}
