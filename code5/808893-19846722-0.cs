    public static Task<TResult> FromResult<TResult>(TResult result)
    {
        var completionSource = new TaskCompletionSource<TResult>();
        completionSource.SetResult(result);
        return completionSource.Task;
    }
