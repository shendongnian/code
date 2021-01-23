    class A
    {
      public virtual void F() { Console.WriteLine("A::F()"); }
      public virtual void G() { Console.WriteLine("A::G()"); }
    }
    class B : A
    {
      public override void F() { Console.WriteLine("B::F()"); }
      public new void G() { Console.WriteLine("B::G()"); }
      public static void Main()
      {
        A a = new B();
        B b = new B();
        a.F();
        b.F();
        a.G();
        b.G();
      
        Console.ReadLine();
      }
    }
