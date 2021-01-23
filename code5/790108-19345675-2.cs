    const int MATRIX_ROWS = 3;
    const int MATRIX_COLUMNS = 3;
    List<int> l = new List<int>();
    
    double[,] matrix = new double[MATRIX_ROWS, MATRIX_COLUMNS];
    for (int i = 0; i < MATRIX_ROWS * MATRIX_COLUMNS; ++i)
    {
            double input;
            Console.Write("Enter value");
            while (!double.TryParse(Console.ReadLine(), out input))
            {
                Console.Write("Enter correct value!");
            }
            l.Add(input);
    }
    l.Sort();
    for (int i = 0; i < MATRIX_ROWS; i++)
    {
        for (int j = 0; j < MATRIX_COLUMNS; j++)
        {
            matrix[i, j] = l[i*3 + j];
        }
    }
