    [Flags]
    enum First
    {
        None = 0,
        P = 1,
        O = 2,
        Z = 4
    }
    [Flags]
    enum Second
    {
        None = 0
        T = 1,
        C = 2,
        P = 4,
        M = 8
    }
    void YourMethod(First first, Second second)
    {
        bool hasP = first.HasFlag(First.P);
        var hasT = second.HasFlag(Second.T);
    }
