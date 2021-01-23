    public static void ForgetOrThrow(this Task task)
    {
        task.ContinueWith((t) => { 
            throw t.Exception
        }, TaskContinuationOptions.OnlyOnFaulted);
    }
