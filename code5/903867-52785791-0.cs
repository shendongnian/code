    public static async Task<TResult> WithCompletionResult<TResult>(
        this Task sourceTask,
        TResult result
    )
    {
        await sourceTask;
        return result;
    }
