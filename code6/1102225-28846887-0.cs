    static void Main(string[] args)
    {
        for (int x = 2; x < 10000; x++)
        {
            bool isPrime = true;
            for (int y = 1; y < x; y++)
            {
                if (x % y == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if(isPrime)
               Console.WriteLine(x);
        }
        Console.ReadKey();
    }
