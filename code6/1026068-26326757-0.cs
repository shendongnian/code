    public static void myString(int n)
    {
        Random rand = new Random();
        for (int i = 1; i <= n; i++)
        {
            int x = rand.Next(65, 90); // Changed here.
            char c = (char)x;
            Console.Write(c);
        }
        Console.WriteLine();
    }
