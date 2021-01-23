    public void SwapDelegateOrder(object obj, string eventName)
    {
        // Fetch the underlying event handler field (let's *assume* it has the same name):
        var delegateField = obj.GetType().GetField(eventName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        var mcDelegate = delegateField.GetValue(obj) as MulticastDelegate;
        if (mcDelegate == null)
            return;
    
        // Get the add and remove methods:
        var evt = obj.GetType().GetEvent(eventName);
        var add = evt.GetAddMethod(true);
        var remove = evt.GetRemoveMethod(true);
    
        // Remove all invocations...
        var invocations = mcDelegate.GetInvocationList();
        foreach (var invocation in invocations)
            remove.Invoke(obj, new object[] { invocation });
    
        // ...and add them back in, in reverse order (*assuming* that invocations are called in the order they're added):
        foreach (var invocation in invocations.Reverse())
            add.Invoke(obj, new object[] { invocation });
    }
