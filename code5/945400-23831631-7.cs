    class Program
    {
        static void Main(string[] args)
        {
            AlwaysEmit();
            DebugEmit();
            VerboseEmit();
        }
        public static void AlwaysEmit()
        {
            Console.WriteLine("Beam me up");
        }
        [Conditional("DEBUG")]
        public static void DebugEmit()
        {
            Console.WriteLine("Kirk out");
        }
        [Conditional("VERBOSE")]
        public static void VerboseEmit()
        {
            Console.WriteLine("Say that again?");
        }
    }
