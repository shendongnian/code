    [Flags]
    public enum Flags
    {
        F1 = 1,
        F2 = 2
    }
    public  void Func(Flags f = (Flags.F1 | Flags.F2)) {
        // body
    }
