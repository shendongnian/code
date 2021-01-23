    public static void F<TU, TT>() where TU : IE<TT>
    {
    }
    static void Foo()
    {
        F<A<int>, int>();
    }
