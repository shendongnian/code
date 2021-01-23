    var queue = new ConcurrentQueue<string>();
	var consume = true;
	
	var producer = Task.Run(() => 
	{
	    var input = Console.ReadLine();
        while(!string.IsNullOrEmpty(input) 
        {
           queue.Enqueue(input);
           input = Console.ReadLine();         
	    }
    });
	
	var consumer = Task.Run(() => 
	{
		while(consume) //So we can stop the consumer
		{
			while(!queue.IsEmpty) //So we empty the queue before stopping
			{
				stringres;
				if(queue.TryDequeue(out res)) Console.WriteLine(res);
			}
		}
	});
	await producer;
	consume = false;
	await consumer;
