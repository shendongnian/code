    const int MATRIX_ROWS = 3;
    const int MATRIX_COLUMNS = 3;
    
    double[,] matrix = new double[MATRIX_ROWS, MATRIX_COLUMNS];
    
    for (int i = 0; i < MATRIX_ROWS; i++)
    {
        for (int j = 0; j < MATRIX_COLUMNS; j++)
        {
            double input;
            Console.Write("Enter value for ({0},{1}): ", i, j);
            while (!double.TryParse(Console.ReadLine(), out input)
            {
            	Console.Write("Enter correct value for ({0},{1}): ", i, j);
            }
            matrix[i,j] = input
        }
    }
