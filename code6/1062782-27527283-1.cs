    class Base
    {
         public int Amount = 0;
    }
    class Derived : Base
    {
         public Derived() // You don't need to explicitly call base().
         {
             Amount = 10;
         }
    }
    void Main()
    {  
        Derived d = new Derived();
        Console.WriteLine(d.Amount); // should print 10.
        Base b = d;
        Console.WriteLine(b.Amount); // should print 10 as well.
    }
