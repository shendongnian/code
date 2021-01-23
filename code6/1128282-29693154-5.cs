    private object padLock = new object();
    private Task<int> executingTask;
    public async Task<int> GetValue() 
    {
        Task<int> getValueTask;
    
        lock(padLock)
        {
            if (executingTask  == null || executingTask.IsCompleted)
                getValueTask = executingTask= GetValueFromServer();
            else
                getValueTask = executingTask;
        }
    
        var value = await getValueTask;
        return value;
    }
