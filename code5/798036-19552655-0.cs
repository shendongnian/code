    Console.WriteLine(Foo()); // This prints 10
    ...
    static int Foo()
    {
        int x = 10;
        try
        {
            return x;
        }
        finally
        {
            // This executes, but doesn't change the return value
            x = 20;
            // This executes before 10 is written to the console
            // by the caller.
            Console.WriteLine("Before Foo returns");
        }
    }
