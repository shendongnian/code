    // Console Application Example #1 ;)
    static void Main()
    {
        Func<int, int> myfunc = null;
        myfunc = Add2;
        Console.WriteLine(myfunc(7)); // This prints 9
        myfunc = MultBy2;
        Console.WriteLine(myfunc(7)); // This prints 14
    }
    static int Add2(int x)
    {
        // This method adds 2 to its input
        return x + 2;
    }
    static int MultBy2(int x)
    {
        // This method  multiplies its input by 2
        return x * 2;
    }
