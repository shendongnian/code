    public static void ForgetOrThrow(this Task task)
    {
        task.ContinueWith((t) => {
            Console.WriteLine(t.Exception);
        }, TaskContinuationOptions.OnlyOnFaulted);
    }
