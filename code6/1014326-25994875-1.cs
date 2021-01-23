    private static void Method(IEnumerable<int> enumerable)
    {
        var x = enumerable;
        System.Threading.Monitor.Enter(x);
        try
        {
            var list = enumerable.ToList();
        }
        finally
        {
            System.Threading.Monitor.Exit(x);
        }
    }
