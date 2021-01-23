    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            Console.WriteLine(a.GetName());
            a = new B();
            Console.WriteLine(a.GetName());
            a = new C();
            Console.WriteLine(a.GetName());
        }
    }
    public class A
    {
        public virtual string GetName()
        {
            return "A";
        }
    }
    public class B : A
    {
        public override string GetName()
        {
            return "B";
        }
    }
    public class C : B
    {
        public override string GetName()
        {
            return "C";
        }
    }
