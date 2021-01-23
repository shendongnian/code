    private static void showObjectCounter()
    {
        Counter val1 = new Counter();
        Console.WriteLine("Total objects created = {0}", Counter.objectCount());
        Counter val2 = new Counter();
        Console.WriteLine("Total objects created = {0}", Counter.objectCount());
        Counter val3 = new Counter();
        Console.WriteLine("Total objects created = {0}", Counter.objectCount());
        Counter val4 = new Counter();
        Console.WriteLine("Total objects created = {0}", Counter.objectCount());
    }
