    class Base
    {
         public int Amount = 0;
    }
    class Derived : Base
    {
         public int Amount = 10;
    }
    void Main()
    {  
        Derived d = new Derived();
        Console.WriteLine(d.Amount); // should print 10.
        Base b = d;
        Console.WriteLine(b.Amount); // should print 0.
    }
