    static void Main(string[] args)
    {
        int rowHeight = 5;
        for (int row = 1; row <= rowHeight; row++)
        {
            int totalSpaces = rowHeight - row;
            for (int j = 0; j < totalSpaces; j++)
            {
                Console.Write(" ");
            }
            for (int j = 0; j < row; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
