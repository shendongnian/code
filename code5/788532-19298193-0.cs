    void Main()
    {
    	Timer t = new Timer(ProcessNextItem, null, 0, 1000);
    }
    
    public void ProcessNextItem(object o){
    	var nextTask = Tasks.Take();
    	
    	nextTask.Process(); // Process does the API calls and enqueues new tasks onto Tasks, and sets state of child tasks as needed
    }
    
    public static BlockingCollection<APIRequestTask> Tasks = new BlockingCollection<APIRequestTask>(new ConcurrentQueue<APIRequestTask>());
    
    public abstract class APIRequestTask{
    	public void Process(){}
    	public object State {get;set;}
    }
