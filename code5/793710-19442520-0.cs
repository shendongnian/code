    internal class Program
    {
        private class BaseClass
        {
            public class NestedClass {}
        }
    
        public static bool Function1(BaseClass.NestedClass obj)
        {
            return true;
        }
    
        private static void Main(string[] args)
        {
            Function1(new BaseClass.NestedClass());
            new BaseClass.NestedClass();
            Console.ReadLine();
        }
    }
