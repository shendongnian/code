    List<Action<T>> actions = new List<Action<T>>();
    actions.Add(action1); actions.Add(action2);
    foreach (Action<T> action in actions)
    {
        var t = param; // Replace param with the input parameter
        action(t);
    }
