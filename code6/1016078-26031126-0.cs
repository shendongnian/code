    static void Main(string[] args)
    {
        hold h = new hold();
        h.aa = 88;
        Console.WriteLine("In main " + h.aa);
        thismethod(ref h);
        Console.WriteLine("In main2 " + h.aa);
        Console.WriteLine("In main3 " + ((subhold)h).ss);   // casted, no error.
        Console.ReadKey();
    }
    static void thismethod (ref hold h) {                   // passing by reference
       Console.WriteLine("In thismdethod " + h.aa);
       h.aa += 1;
       Console.WriteLine("In thismdethod1 " + h.aa);
       h = null;
       subhold subhold = new subhold();
       subhold.aa = 8888;
       subhold.ss = 22222;
       h = subhold;
    }
