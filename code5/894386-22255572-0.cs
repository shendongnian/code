    void Main()
    {
      A a = new A();
      B b = new B();
      Print(a);
      Print(b);
    }
    void Print(object o)
    {
      if (o.GetType() == typeof(A))
        "A".Dump();
      else if (o.GetType() == typeof(B))
        "B".Dump();
    }
    class A
    {
    }
    class B : A
    {
    }
