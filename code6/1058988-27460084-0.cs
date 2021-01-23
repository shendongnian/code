    static int[,] values = new int[,]{
        {0, 0, 1, 0, 0},
        {2, 0, 0, 0, 3},
        {0, 4, 1, 1, 0},
        {0, 1, 0, 4 ,1}};
    static void Main(string[] args)
    {
        Parallel.For(0, values.GetLength(0), (row) =>
        {
            for (var column = 1; column < values.GetLength(1); column++)
            {
                values[row, column] += values[row, column - 1];
            }
        });
        for (var row = 0; row < values.GetLength(0); row++)
        {
            for (var column = 0; column < values.GetLength(1); column++)
            {
                Console.Write("{0} ", values[row, column]);
            }
            Console.WriteLine();
        }
