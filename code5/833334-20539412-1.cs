    private static void Main(string[] args)
    {
        MyInt x = new MyInt();
        x.MyValue = 3;
        MyInt y = new MyInt();
        WeakReference reference = new WeakReference(y);
        Console.WriteLine("Y is alive: " + reference.IsAlive);
        y = x;
        y.MyValue = 4;
        Console.WriteLine("Y is still alive: " + reference.IsAlive);
        Console.WriteLine("Running GC... ");
        GC.Collect(2);
        GC.WaitForFullGCComplete();
        Console.WriteLine("Y is alive: " + reference.IsAlive);
        Console.Read();
    }
