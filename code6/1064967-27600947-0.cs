    public void async Page_Load()
     {
    	foreach(var task in tasklist)
    	{
    		await Task.Run(() => fnCallSPForDynamicExec(task.taskid));
    			// Do something on UI	
    	}
     }
     
    private void fnCallSPForDynamicExec (int taskid)
    {
       //call dynamic SP
    }
