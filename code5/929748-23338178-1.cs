    async Task<object> GetData()
    {
        lock (lockTarget)
        {
            if (calculation != null && !calculation.IsCompleted)
            {
                return calculation;
            }
            
            return calculation = Task.Run<object>(RealGetData);
        }
        
    }
