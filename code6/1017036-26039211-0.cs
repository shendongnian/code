    interface IBar { }
    
    static void Bar<T>(IEnumerable<T> value)
        where T : IFoo
    {
    }
    
    static void Bar<T>(T source)
        where T : IBar
    {
        // fails to compile : Type ____ already defines a member called 'Bar' with the same parameter types
    }
