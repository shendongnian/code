    // We use this to keep tasks needed to run in the main thread
    private static readonly Queue<Action> tasks = new Queue<Action>();
    
    
    void Update () {
    	this.HandleTasks();
    }
    
    void HandleTasks() {
    	while (tasks.Count > 0)
    	{
    		Action task = null;
    		
    		lock (tasks)
    		{
    			if (tasks.Count > 0)
    			{
    				task = tasks.Dequeue();
    			}
    		}
    		
    		task();
    	}
    }
    
    public void QueueOnMainThread(Action task)
    {
    	lock (tasks)
    	{
    		tasks.Enqueue(task);
    	}
    }
