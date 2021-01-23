    public class VirtualA
    {
        public virtual string Get()
        {
            return "A";
        }
    }
    public class VirtualB : VirtualA
    {
        public override string Get()
        {
            return "B";
        }
    }
    VirtualA a = new VirtualA();
    VirtualB b = new VirtualB();
    Console.WriteLine(a.Get()); // "A"
    Console.WriteLine(b.Get()); // "B"
    VirtualA c = new VirtualB();
    Console.WriteLine(c.Get()); // "B". We overrode VirtualB.Get, so it's using the 
                                // "B" implementation of the method
