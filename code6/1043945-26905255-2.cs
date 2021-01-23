    public static async Task<Model> GetModelAsync()
    {
        // async logic & return task
    
    }
    public static Model CallGetModelAsyncAndWaitForResult()
    {
        var task = GetModelAsync();
        task.Wait(); // Blocks current thread 
        var result = task.Result;
        return result;
    }
