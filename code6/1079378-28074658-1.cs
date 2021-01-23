    while (threadList.Count > 0)
    {
         Task finishedTask;
         try
         {
              finishedTask = await Task.WhenAny(threadList);
   
             // More processing if needed.
         }
         catch (Exception e)
         {
             // Handle exception.
         } 
         finally
         {
               threadList.Remove(finishedTask);     
         }
    }
