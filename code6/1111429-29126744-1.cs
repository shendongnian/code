    public static void RaiseAsync<T>(this EventHandler<T> handler,
        object sender, T args, SynchronizationContext context)
    {
        if (handler != null)
        {
            context.Post(o => handler(sender, args), null);
        }
    }
