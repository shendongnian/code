    class Program
    {
        static void Main(string[] args)
        {
            bool? test = null;
            if (test ?? false)
            {
                Console.WriteLine("ok");
            }
            Console.ReadKey();
        }
    }
