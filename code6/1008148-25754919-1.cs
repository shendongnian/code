    class A
    {
    public A()
    {
    B = new B();
    }
    public B B { get; set; }
    }
    class B
    {
    public B()
    {
    C = new C();
    }
    public C C { get; set; }
    }
    class C
    {
    public String Text { get; set; }
    }
