      static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to calculate: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Fib(0, 1, 1, num);
        }   
        
        public static void Fib(int i, int j, int count, int num)
        {
            Console.WriteLine(i);
            if (count < num) Fib(j, i+j, count+1, num);
        }
