    public async Task Example()
    {
        Foo();
        var task = BarAsync();
        var awaiter = task.GetAwaiter();
        Action postback = () => 
        {
             string barResult = awaiter.GetResult();
             Baz(barResult)
        }
        if(awaiter.IsCompleted)
            postback();
        else
        {
            var castAwaiter = awaiter as ICriticalNotifyCompletion;
            if(castAwaiter != null)
            {
                castAwaiter.UnsafeOnCompleted(postback);
            }
            else
            {
                var context = SynchronizationContext.Current;
                if (context == null)
                    context = new SynchronizationContext();
                var contextCopy = context.CreateCopy();
                awaiter.OnCompleted(() => contextCopy.Post(postback, null));
            }
        }
        return task;
    }
