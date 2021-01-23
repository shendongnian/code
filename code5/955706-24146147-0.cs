    public class HidingA
    {
        public string Get()
        {
            return "A";
        }
    }
    public class HidingB : HidingA
    {
        public new string Get()
        {
            return "B";
        }
    }
    HidingA a = new HidingA();
    HidingB b = new HidingB();
    Console.WriteLine(a.Get()); // "A"
    Console.WriteLine(b.Get()); // "B"
    HidingA c = new HidingB();
    Console.WriteLine(c.Get()); // "A". Since we're calling this instance of "B" an "A",    
                                //we're using the "A" implementation.
