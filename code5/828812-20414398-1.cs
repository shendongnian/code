    public class Program {
        public static void Main() {
            var dynamicTest = new DynamicMethodTest();
            Console.WriteLine(dynamicTest.Evaluate(15)); // False
            dynamicTest.PerformInjection("if (number > 5) { return true; } else { return false; }");
            Console.WriteLine(dynamicTest.Evaluate(15)); // True
            Console.Read();
        }
    }
