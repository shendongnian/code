        class Program
    {
        static void Main(string[] args)
        {
            M(new A()); // will work
            M(new B()); // will work
            M(new C()); // will work
            M(new D()); // wont work
        }
        public static string M<T>(T arg)
            where T : A
        {
            return arg.Data;
        }
    }
    public class A
    {
        public string Data { get; set; }
    }
    public class B : A
    {
        
    }
    public class C : B
    {
        
    }
    public class D
    {
        
    }
