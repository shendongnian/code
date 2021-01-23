    class Program
      {
       static List<Task>  allTasks = new List<Task>();
        static void Main(string[] args)
        {
            foreach (myTask T in this.TaskList)
                {
           if (T.NextRunTime<=Now);
                   var task=  Task.Factory.StartNew(() => T.runTask().Start());
                     task.ContinueWith( delegate
                                                  {
                                                      //code  for your continuation 
                                                      //you can call the method for doing this  
                                                  },TaskContinuationOptions.NotOnFaulted);
                     try
                     { // and here to handle all  your exceptions  
                         task.Wait();
                     }
                     catch (AggregateException ae)
                     {
                         ae.Handle((x) =>
                         {
                            
                             return true;
                         });
                     }
                }
            //you can even try someting  like this  
            // Task.WaitAll(allTasks.ToArray());  
        }
    }
