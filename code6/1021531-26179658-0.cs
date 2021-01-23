    class Program
    {
        private static int z = 300;
        private static int y = z - 10;    
        private static int x = y + 100;       
        public static void Main(string[] args)
        {
            System.Console.WriteLine("{0}/{1}/{2}",x,y,z);
            Console.ReadKey();
        }
    }
