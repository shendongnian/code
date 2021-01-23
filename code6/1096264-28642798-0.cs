     class Program
    {
        //add static in front of string
        static String a = "Hello";
        static void Main(string[] args)
        {
            h();
            Console.ReadKey();
        }
        public static void h()
        {
            Console.WriteLine(a);
        }
    }
