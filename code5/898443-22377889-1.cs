    public void doA()
    {
         for (int i = 0; i < NumberOfTasks; i++)
         {
              tasks[i] = Task.Factory.StartNew(() =>
              {
                   try
                   {
                        //enter tasks here 
                        // i.e. task 1, 2, 3, 4
                   }
              }
         }, token);
     
         Task.WaitAll(tasks);    
    }
    
