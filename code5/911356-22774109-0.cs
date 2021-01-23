    for (int r = 0; r < Rows; r++)
    {
        bool rowOkay = true;
        for (int c = 0; c < Cols; c++)
        {
            if (m[r, c] <= 0)
            {
                rowOkay = false;
            }
        }
        if (rowOkay)
        {
            for(int i=0;i<Cols;++i) {Console.Write("{0} ", m[r,i]);}
            Console.WriteLine();
        }
    }
