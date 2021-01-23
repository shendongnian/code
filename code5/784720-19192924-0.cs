    private object SqlSearch(CancellationToken token)
        {
           Random random = new Random();
           object result = 1;
           try 
           {
             bool done= false;
            while (true )
            {
                if(!done)
                {
                    // random numbers to simulate number of results
                    result = random.Next(1, 13); 
                   done = true;
                }
                token.ThrowIfCancellationRequested();
                Thread.Sleep(200);
            }
         }
         catch
         {
            return result;
         }
      }
