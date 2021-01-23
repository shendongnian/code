    class Base
    {
       public static void BaseMethod() { Console.WriteLine("BASE!"); }
    }
    
    class Derived : Base
    {
       // Hides Base.BaseMethod()
       new public static void BaseMethod() { Console.WriteLine("DERIVED!"); }   
    }
    
    Base a = new Base();
    a.BaseMethod(); // -> "BASE!"
    
    Base b = new Derived();
    b.BaseMethod(); // -> "BASE!"
    
    Derived b = new Derived();
    b.BaseMethod(); // -> "DERIVED!"
