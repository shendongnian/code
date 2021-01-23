    class Program
    {
        static void Main(string[] args)
        {
            string bar = ReturnMeNull();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
            for (int i = 0; i < bar.Length; i++)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
            return;
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        static string ReturnMeNull()
        {
            return null;
        }
    }
