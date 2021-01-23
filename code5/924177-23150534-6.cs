    public static void RaiseAsync<T>(this EventHandler<EventArgs<T>> theEvent, object sender, T args)
    {
        if (theEvent != null)
        {
            var eventArgs = new EventArgs<T>(args);
            foreach (EventHandler<EventArgs<T>> action in theEvent.GetInvocationList())
                action.BeginInvoke(sender, eventArgs, null, null);
        }
    }
