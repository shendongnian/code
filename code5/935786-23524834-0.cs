    public static Task WrapExceptions(this Func<Task> function)
    {
        try
        {
            return function();
        }
        catch (Exception e)
        {
            var tcs = new TaskCompletionSource<bool>();
            tcs.SetException(e);
            return tcs.Task;
        }
    }
