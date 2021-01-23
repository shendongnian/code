    public static Task WhenExited(this Process process)
    {
        var tcs = new TaskCompletionSource<bool>();
        process.EnableRaisingEvents = true;
        process.Exited += (s, args) => tcs.TrySetResult(true);
        return tcs.Task;
    }
