    static void m1()
    {
        lock(obj)
        {
            Monitor.Enter(obj);
            Console.WriteLine("m1");
        }
        
        Console.WriteLine("m1 has lock on obj: ", Monitor.IsEntered(obj));
    }
