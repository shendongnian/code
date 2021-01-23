    class Program
    {
        static byte test(uint capacity, uint free)
        {
            return (byte)((capacity - free) / (float)capacity * 100);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(test(uint.MaxValue, uint.MaxValue));
            Console.WriteLine(test(0, 0));
            Console.WriteLine(test(uint.MaxValue, 0));
            Console.WriteLine(test(0, uint.MaxValue));
        }
    }
