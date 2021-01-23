    private object padLock = new object();
    private Task<int> executingTask;
    public async Task<int> GetValue() 
    {  
        lock(padLock)
        {
            if (executingTask  == null || executingTask.IsCompleted)
                executingTask= GetValueFromServer();
        }
    
        var value = await executingTask;
        return value;
    }
