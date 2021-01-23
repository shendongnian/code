    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsInt(3.0m)); // True
            Console.WriteLine(IsInt(3.1m)); // False
        }
        public static bool IsInt(decimal variable)
        {
            return ((variable % 1) == 0);
        }
    }
