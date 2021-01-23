    class Program
    {
        static void Main(string[] args)
        {
            var returnedFunction = TestClass.FunctionToReturnAStaticMethod();
            returnedFunction();
        }
    }
    public class TestClass
    {
        public delegate void TypeOfFunctionToReturn();
        public static TypeOfFunctionToReturn FunctionToReturnAStaticMethod()
        {
            return () => StaticMethod();
        }
        public static void StaticMethod()
        {
            Console.WriteLine("\"StaticMethod\" called");
        }
    }
