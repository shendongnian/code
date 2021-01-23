    static int[,] values = new int[,]{
        {0, 0, 1, 0, 0},
        {2, 0, 0, 0, 3},
        {0, 4, 1, 1, 0},
        {0, 1, 0, 4 ,1}};
    static void Main(string[] args)
    {
        int rows=values.GetLength(0);
        int columns=values.GetLength(1);
        Parallel.For(0, rows, (row) =>
        {
            for (var column = 1; column < columns; column++)
            {
                values[row, column] += values[row, column - 1];
            }
        });
        for (var row = 0; row < rows; row++)
        {
            for (var column = 0; column < columns; column++)
            {
                Console.Write("{0} ", values[row, column]);
            }
            Console.WriteLine();
        }
