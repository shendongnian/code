    interface IFoo
    {
        void Hello1();
        void Hello2();
    }
    
    interface IBar
    {
        void World1();
        void World2();
    }
    
    class A1 : IFoo, IBar
    {
    //.....
    }
    
    var a = new A1();
    
    var f = a as IFoo; // Get IFoo methods.
    
    Console.WriteLine(f.Hello1());
    
    var b = a as IBar; // Get IBar methods.
    
    Console.WriteLine(b.World2());
