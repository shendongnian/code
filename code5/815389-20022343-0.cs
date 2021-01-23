    class Thing
    {
        void DoSomething()
        {
            Console.WriteLine("Thing");
        }
    }
    
    class Other : Thing
    {
        new void DoSomething()
        {
            Console.WriteLine("Other");
        }
    }
    
    var thing = new Thing();
    thing.DoSomething(); \\ prints Thing
    
    var other = new Other();
    other.DoSomething(); \\ prints Other
    
    ((Thing)other).DoSomething(); \\ prints Thing
