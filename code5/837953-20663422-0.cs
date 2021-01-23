          try
            {
                YourSNMPTrapSenderMethod();
            }
           catch (AggregateException ae)
            {
                // This is where you can choose which exceptions to handle. 
                foreach (var ex in ae.InnerExceptions)
                {
                   // log your exception. may be in temp directory
                }
            }
    
