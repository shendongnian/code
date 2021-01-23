    static void Main(string[] args)
    {
        int i = 1;
        while (i <= 5)
        {
            int k = 5;
            int h = 1;
    
            Console.WriteLine("");
            while (k > i)
            {
                Console.Write(" ");
                k--;
            }
            while (h <= i)
            {
                Console.Write("**");
                h++;
            }
            i++;
        }
        Console.ReadLine();
    }
