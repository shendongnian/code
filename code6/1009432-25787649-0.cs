    public abstract class MainClass
    {
        public virtual void test()
        {
            Console.WriteLine("This is the abstract class");
        }
    }
    public class A : MainClass
    {
        public override void test()
        {
            base.test();
            Console.WriteLine("Class A");
        }
    }
    public class B : MainClass
    {
        public override void test()
        {
            base.test();
            Console.WriteLine("Class B");
        }
    }
    public class Intermediate
    {
        public MainClass CreateInstance(string name)
        {
            if (name.ToUpper() == "A")
            {
                return new A();
            }
            else
            {
                return new B();
            };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Intermediate intermediate = new Intermediate();
            var client = intermediate.CreateInstance("B");
            client.test();
            Console.ReadLine();
        }
    }
