    public Func<bool> GetCancelRequestedFunc(string taskName)
    {
        DateTime lastExecution = DateTime.Now;
    
        return () =>
        {
            if(lastExecution.AddMinutes(5)<DateTime.Now) 
            {
                lastExecution = DateTime.Now;
                bool result;
    
                //long operation here
    
                return result;
            }
    
            return false;
        };
    }
