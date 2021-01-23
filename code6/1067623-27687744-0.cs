    struct Demo
    {
        public int SomeField;
    }
    internal static class Program
    {
        static Demo demo = new Demo { SomeField = 5 };
        private static void Main()
        {
            Print();
        }
        public static unsafe void Print()
        {
            fixed (Demo* demop = &demo)
            {
                Console.WriteLine(demop->SomeField);
            }
        }
    }
