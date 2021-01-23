    public static void Main(string[] args)
    {
            var rnd = new Random();
            Console.WriteLine("\n5 random integers from -100 to 100:");
            List<int> random = new List<int>();
    
            for (int X = 1; X <= 5; X++)
            {
                random.Add(rnd.Next(-100, 100));
            }
            Console.WriteLine("These are the positive numbers:");
            foreach (int number in random)
            {
                if (number >= 0)
                {
                    Console.WriteLine(number);
                }
            }
            Console.WriteLine("These are the negative numbers:");
            foreach (int number in random)
            {
                if (number < 0)
                {
                    Console.WriteLine(number);
                }
            }
            Console.ReadLine();
        }
