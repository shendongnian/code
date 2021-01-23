    public class BaseClass { }
    public class DerivedClass : BaseClass { }
    static class Program
    {
        static void Main(string[] args)
        {
            var composed = Compose<DerivedClass>(Test, () => Console.WriteLine(" world"));
            composed(new DerivedClass());
            Console.ReadLine();
        }
        public static void Test(BaseClass arg)
        {
            Console.Write(arg);
        }
    }
