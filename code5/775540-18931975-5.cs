    namespace GetTypeTest
    {
        public class FindMe { }
        class Program
        {
            static void Main(string[] args)
            {
                var assemblyName = Assembly.GetExecutingAssembly().FullName;
                var className = "System.Linq.Expressions.Expression";//"GetTypeTest.FindMe";
                var classAndAssembly = string.Format("{0}, {1}", className, assemblyName);
                // 1) GetType succeeds when input is "class, assembly", using method group
                var result = new[] { classAndAssembly }.Select(Type.GetType).ToArray();
                Console.WriteLine("1) Method group & class+assembly: {0}, {1}", result.First(), result.First().Assembly);//your assembly
                // 2) GetType fails when input is just the class name, using method group
                var result2 = new[] { className }.Select(Type.GetType).ToArray();
                Console.WriteLine("2) Method group & class name only: {0}, {1}", result2.First(), result2.First().Assembly);//System.Core assembly
                // 3) Identical to (2) except using lamba expression - this succeeds...
                var result3 = new[] { className }.Select(s => Type.GetType(s)).ToArray();
                Console.WriteLine("3) Lambda expression & class name only: {0}, {1}", result3.First(), result3.First().Assembly);//your assembly
                // 4) Method group and core type class name
                var result4 = new[] { "System.String" }.Select(Type.GetType).ToArray();
                Console.WriteLine("4) Method group for System.String: {0}, {1}", result4.First(), result4.First().Assembly);//mscorlib assembly
                Console.ReadLine();
            }
        }
    }
    namespace System.Linq.Expressions
    {
        public class Expression
        {
        }
    }
