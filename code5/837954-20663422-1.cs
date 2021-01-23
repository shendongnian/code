            try
            {
                YourSNMPTrapSenderMethod();
            }
            catch (AggregateException ex)
            {
                ex.Handle((x) =>
                {
                    Log.Write(x);
                    return true;
                });
            }
       static void YourSNMPTrapSenderMethod()
        {
            var exceptions = new ConcurrentQueue<Exception>();
            Parallel.ForEach(data, d =>
            {
                try
                {
                  //do your operations
                }
                                   
                catch (Exception e) { exceptions.Enqueue(e); }
            });
    
           
            if (exceptions.Count > 0) throw new AggregateException(exceptions);
        }
