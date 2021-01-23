    static void Main(string[] args)
    {
        int rowHeight = 5;
        for (int row = 1; row <= rowHeight; row++)
        {
            string spaces = new string(' ', rowHeight - row);
            string stars = new string('*', row);
            Console.WriteLine("{0}{1}", spaces, stars);
        }
        Console.ReadLine();
    }
