    public class Program
    {
        static void Main(string[] args)
        {
            TestString("2");
            TestString("2.0");
            TestString("true");
            TestString("nnn");
        }
        static void TestString(string testString)
        {
            object result = GenericParser.Parse(testString);
            Console.WriteLine("\"{0}\"\t => {1}", testString, result.GetType().Name);
        }
    }
