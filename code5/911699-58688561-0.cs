    public static Task<TEventArgs> TaskFromEvent<TDelegate, TEventArgs>(
        Action<TDelegate> addHandler, Action<TDelegate> removeHandler)
        where TDelegate : Delegate where TEventArgs : EventArgs
    {
        var tcs = new TaskCompletionSource<TEventArgs>();
        TDelegate specificHandler = null;
        Action<object, TEventArgs> handler = (sender, e) =>
        {
            removeHandler(specificHandler);
            handler = null;
            tcs.SetResult(e);
            tcs = null;
        };
        var invokeMethodInfo = typeof(Action<object, TEventArgs>).GetMethod("Invoke");
        specificHandler = (TDelegate)invokeMethodInfo
            .CreateDelegate(typeof(TDelegate), handler);
        addHandler(specificHandler);
        return tcs.Task;
    }
