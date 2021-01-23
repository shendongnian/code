    IEnumerable<Int32> Fibonacci(Int32 limit = 4000000)
    {
        for (Int32 p = 0, c = 1, n = 0; c <= limit; c = n)
        {
            n = p + c;
            p = c;
            yield return n;
        }
    }
