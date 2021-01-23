    public static T Add<T>(T x, T y)
    {
        return (T)((dynamic)x+(dynamic)y);
    }
    static void Main(string[] args)
    {
        int a=Add(10, 11);
        long b=Add(34L, 23L);
        uint c=Add(4u, 15u);
    }
