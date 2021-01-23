     class Program
    {
        static void Main(string[] args)
        {
            int i = 0; 
            int c = SampleClass.ExampleMethod(ref i); Console.WriteLine("i={0} - c={1}", i, c);
            Console.ReadLine();
        }
    }
    class SampleClass
    {
        public static int ExampleMethod( ref int i)
        {
            i = 101;
            return i;
        }
    }
