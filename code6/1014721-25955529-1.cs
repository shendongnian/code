    static void Main(string[] args)
    {
        var a = new A();
        foreach (var i in Enumerable.Range(1,3))
        {
            a.GetType().GetProperty("P" + i).SetValue(a, i, null);
        }
        Console.WriteLine("P1 = {0}",a.P1);
        Console.WriteLine("P2 = {0}",a.P2);
        Console.WriteLine("P3 = {0}",a.P3);
        Console.ReadLine();
    }
