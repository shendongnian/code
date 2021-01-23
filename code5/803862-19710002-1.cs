    public void Action1(int x) { ... }
    public void Action2(int x) { ... }
    public void Action3(int x) { ... }
    ...
    Action<int>[] actions = new Action<int>[] { Action1, Action2, Action3 }
    for (int i = 0; i < actions.Length; i++)
    {
        actions[i](i);  // Invoke the delegate with (...)
    }
