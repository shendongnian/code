    void Main()
    {
    	// Create your unity container (one-time creation)
        UnityContainer uc = new UnityContainer();
    
        // Create simple list to hold your target objects
        // (makes the sample easy to follow)
        List<MessageQueue> allMQs = new List<MessageQueue>();
    
        // I'm adding TransientLifetimeManager() in order to 
        // explicitly ask for new object creation each time
        // uc.Resolve<MessageQueue>() is called
        uc.RegisterType<IQueue, MessageQueue>(new TransientLifetimeManager());
    // ### override the parameters by matching the parameter name (inPath)
        var item = uc.Resolve<MessageQueue>(new ParameterOverride("inPath", "extra.txt").OnType<MessageQueue>());
        allMQs.Add(item);
        item = uc.Resolve<MessageQueue>(new ParameterOverride("inPath", "super.txt").OnType<MessageQueue>());
        allMQs.Add(item);
    	
    	foreach (MessageQueue mq in allMQs){
    		Console.WriteLine($"mq.Path : {mq.Path}");
    	}
    	
    	Console.WriteLine("######################\n");
    
    	uc.RegisterType<Example>(new InjectionConstructor((allMQs[0] as IQueue),(allMQs[1] as IQueue)));
    	
    	// #### Create a new Example from the UnityContainer
    	var example1 = uc.Resolve<Example>();
    	// ##### Notice that the Example object uses the default values of super.txt & extra.txt
    	
    	Console.WriteLine("#### example1 obj. uses default values ###########");
    	Console.WriteLine($"example1.receiver.Path : {example1.receiver.Path}");
    	Console.WriteLine($"example1.sender.Path : {example1.sender.Path}");
    	
    	// ##################################################
    	// Override the parameters that he Example class uses.
     // ### override the parameters by matching the parameter 
     // names (receiveQueue, sendQueue) found in the target
    // class constructor (Example class)
    	var example2 = uc.Resolve<Example>( 
    		new ParameterOverrides {
    			 {"receiveQueue", new MessageQueue("newReceiveFile")},
    			 { "sendQueue", new MessageQueue("newSendFile")}
    		}.OnType<Example>());
    
    	Console.WriteLine("######################\n");
    	
    	Console.WriteLine("#### example1 obj. uses ParameterOverride values ###########");
    	Console.WriteLine($"example2.sender.Path : {example2.sender.Path}");
    	Console.WriteLine($"example2.receiver.Path : {example2.receiver.Path}");
    }
    
    class Example
    {
       public MessageQueue receiver {get;set;}
       public MessageQueue sender {get;set;}
       
       public Example(IQueue receiveQueue, IQueue sendQueue) {
       	this.receiver = receiveQueue as MessageQueue;
    	this.sender = sendQueue as MessageQueue;
    	
       }
    }
    
    public class MessageQueue : IQueue
    {
    	public string Path {get;set;}
        public MessageQueue(string inPath) {
    		Path = inPath;}
    }
    
    interface IQueue{
    	
    }
