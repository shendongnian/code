    static Expression<Func<int, int>> otherFunc;
    public static void MyMethod(Expression<Func<int, int>> func)
    {
        if (otherFunc == null)
        {
            otherFunc = func;
            Console.WriteLine("First time");
        }
        else
        {
            Console.WriteLine("Same Expression<Func<int>>: {0}", object.ReferenceEquals(func, otherFunc));
            Console.WriteLine("Same Parameter: {0}", object.ReferenceEquals(func.Parameters[0], otherFunc.Parameters[0]));
        }
    }
