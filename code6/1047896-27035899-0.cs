    for (col = 0; col < vektor.GetLength(1); col++)
    {
        totcol = 0; // <--- reset the sum to 0.
    
        for (row = 0; row < vektor.GetLength(0); row++)
        {
            totcol += vektor[row, col];
        }
        Console.Write(totcol + "\t");
    }
