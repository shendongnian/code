         Parallel.ForEach(myList, (item) =>
         {
             Task task = Task.Factory.StartNew(() =>
             {
                 Process(item));
             });
    
             if(task.Wait(10000)) // Specify overall timeout for Process() here
                 Console.WriteLine("Didn't Time out. All's good!"); 
             else
                 Console.WriteLine("Timed out. Leave this one and continue with the rest"); 
         });
