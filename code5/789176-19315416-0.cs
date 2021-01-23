    public static int Fibonacci(int x)
    {
        var t = new Dictionary<int, int>();
        Func<int, int> fibCached = null;
        fibCached = n =>
        {
            if (t.ContainsKey(n)) return t[n];
            if (n <= 2) return 1;
            var result = fibCached(n – 2) + fibCached(n – 1);
            t.Add(n, result);
            return result;
        };
        return fibCached(x);
    }
