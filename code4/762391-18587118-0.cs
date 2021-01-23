    static void Main()
    {
        IEnumerable<object> e = new List<object>();
        var r = Generic(e);
    }
    static string Generic<T>(T x)
    {
        return Overloaded(x);
    }
    static string Overloaded(IEnumerable<object> x)
    {
        return "Enumerable";
    }
    static string Overloaded(object x)
    {
        return "Object";
    }
