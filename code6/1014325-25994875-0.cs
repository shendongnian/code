    private static void Method(IEnumerable<int> enumerable)
    {
        lock (enumerable)
        {
            var list = enumerable.ToList();
        }
    }
