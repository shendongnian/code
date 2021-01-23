    static void Main(string[] args)
    {
        object obj1 = Foo();
        
        using (IDisposable disp = obj1 as IDisposable)
        {
            // operate on obj1 only since disp might be null
        }
    }
