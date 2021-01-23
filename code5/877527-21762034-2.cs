    static T add<T>(T a, T b) {
        var p0 = Expression.Parameter(typeof(T));
        var p1 = Expression.Parameter(typeof(T));
        var ae = Expression.Add(p0, p1);
        var f = (Func<T,T,T>)Expression.Lambda(ae, p0, p1).Compile();
        return f(a, b);
    }
    int a = 4, b = 6;
    double x = 2.3, y = 5.2;
    Console.WriteLine("Sum of two ints = {0}", add(a, b));
    Console.WriteLine("Sum of two doubles = {0}", add(x, y));
