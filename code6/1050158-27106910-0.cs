    private void ProcessResult<TResult>(Task<TResult> task)
    {
        if (task.IsFaulted)
        {
            //remove from cahe
        }
        else if (task.IsCompleted)
        {
            //add to cache
        }
    }
