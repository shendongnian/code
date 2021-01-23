    public T Await<T>(Func<T> fun, int millis)
    {
        using (var cancel = new CancellationTokenSource(millis))
        using (var task = new Task<T>(() =>
        {
            T result = default(T);
            var thread = new Thread(() => result = fun());
            thread.Start();
            while (!cancel.Token.IsCancellationRequested && thread.IsAlive) ; // Wait for a sign from above
            thread.Abort();
            cancel.Token.ThrowIfCancellationRequested();
            return result;
        }, cancel.Token))
        {
            task.Start();
            task.Wait(millis);
            cancel.Cancel();
            if (!task.IsCompleted) throw new TimeoutException();
            return task.Result;
        }
    }
