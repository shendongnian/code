    static void A()
    {
        {
            var o = new object();
            Console.WriteLine(o);
        }
        var p = new object();
        Console.WriteLine(p);
    }
    static void B()
    {
        var o = new object();
        Console.WriteLine(o);
        var p = new object();
        Console.WriteLine(p);
    }
    static void C()
    {
        {
            var o = new object();
            Console.WriteLine(o);
        }
        {
            var o = new object();
            Console.WriteLine(o);
        }
    }
