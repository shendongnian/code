    var taskAction = new Action(() =>
    {
	    try{
            Thread.Sleep(1000); 
            Console.WriteLine("Task Waited for a sec");
            throw (new Exception("throwing for example"));
	    }
	    catch (Exception e)
	    {
	    	Console.WriteLine("In the on Faulted continue with code. Catched exception from the task."+  e);
	    }
   
    });
    Task t = Task.Factory.StartNew(taskAction);
    Console.WriteLine("Main thread waiting for 4 sec");
    Thread.Sleep(4000);
    Console.WriteLine("Wait of 4 secs complete..checking if task is completed?");
    Console.WriteLine("Task State: " + t.Status);
	try{
	 	await t;
	}
	catch{
	  	// do nothing, already logged. 
	}
	
