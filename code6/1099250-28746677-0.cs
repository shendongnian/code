    Action action = callback as Action;
    if (action != null)
    {
        action();
    }
    else
    {
        // ... removed code ..
        obj = callback.DynamicInvoke();
    }
