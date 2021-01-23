    public void DoSomething<T>(string key, Action<T> callback)
    {
        var action1 = callback as Action<string>;
        if (action1 != null)
        {
            action1("my string response");
            return;
        }
        var action2 = callback as Action<int>;
        if (action2 != null)
        {
            action2(1); // my int response
            return;
        }
        // etc...
    }
