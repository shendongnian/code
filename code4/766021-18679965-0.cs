    class Program
    {
        static void Main(string[] args)
        {
            short s = unchecked((short)0x8001);
            int i = s >> 3;
            Console.WriteLine(i);
        }
    }
