    static int CountMinesLeft(string[,] board, string[,] visibilityArray, ref int count)
    {
        if (visibilityArray.Length == 81)
        {
            count = 10;
        }
        else if (visibilityArray.Length == 256)
        {
            count = 40;
        }
        else if (visibilityArray.Length == 480) 
        {
            count = 99;
        }
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int p = 0; p < board.GetLength(1); p++)
            {
                if (visibilityArray[i, p] == "2")
                {
                   count--;
                }
            }
        }
        return count;
