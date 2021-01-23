    System.Threading.Tasks.Schedulers.OrderedTaskScheduler sch = new OrderedTaskScheduler();
    //you could persist this as static or in the kernel of your favorite DI framework    
    var taskFactory = new TaskFactory(sch); 
    
    for(var i = 0; i < 10; ++i)
    {
    	var x = i;
        //these Console operations will occur in order
    	taskFactory.StartNew(() => Console.WriteLine(x));
        //but if we did as below, order would be lost
        //Task.Factory.StartNew(() => Console.WriteLine(x));
    }
