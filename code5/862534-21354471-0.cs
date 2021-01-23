    void Main()
    {
        A a = new A();
        Console.WriteLine(a.One.Two.Three);
    }
    
    public class A
    {
        public B One { get { return new B(); }}
    }
    
    public class B
    {
        public C Two { get { return new C(); }}
    }
    
    public class C
    {
        public string Three { get { return "Test"; }}
    }
