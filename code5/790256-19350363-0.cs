            public static void Main(String[] args)
            {
            int x;
            x = Convert.ToInt32(Console.ReadLine());
            bool y = ((x!=0) && -(x & (x-1))==0);
            if(y)
                Console.WriteLine("The given number is a power of 2");
            else
                Console.WriteLine("The given number is not a power of 2");
            Console.Read();
