    static void Main()
    {
        var a = (TypeA)null;
        var b = (TypeB)null;
        dynamic c = a;
        Method(a);
        Method(b);
        Method(c);   // will throw a `RuntimeBinderException` since the type of c can't be determined at run-time.
    }
