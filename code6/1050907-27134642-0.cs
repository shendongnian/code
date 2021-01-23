    private static int IsWorking = 0;
    private static void Main()
    {
        var originalValue = Interlocked.CompareExchange(ref IsWorking, 1, 0);
    }
