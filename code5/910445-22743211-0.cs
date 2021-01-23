    static void Main(string[] args)
        {
            int first = 1;
            int second = 2;
            Random rng = new Random();
            first = rng.Next(-100, 0);
            Console.WriteLine(first); // I would like to see the result 
            second = rng.Next(-100, 0);
            Console.WriteLine(second); // I would like to see the result 
            if (first > second)
            {
                Console.WriteLine("first is bigger");
            }
            else
            {
                Console.WriteLine("first is smaller");
            }
        }
