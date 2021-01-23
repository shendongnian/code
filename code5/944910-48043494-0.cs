    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            for (a=1; a <= 12; a++) {
                Console.Write("\n");
                for (b = 1; b <= 10; b++)
                {
                    Console.Write("\n "+a* b);
                    
                }
            }
            Console.Read();
        }
    }
}
