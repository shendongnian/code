    static void m1()
    {
        lock(obj)
        {
            Monitor.Enter(obj);
            Console.WriteLine("m1");
        }
    }
