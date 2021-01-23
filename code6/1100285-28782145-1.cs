    static int CountMinesLeft(string[,] board, string[,] visibilityArray, ref int anotherCount)
    {
        if (visibilityArray.Length == 81)
        {
            anotherCount = 10;
        }
        else if (visibilityArray.Length == 256)
        {
            anotherCount = 40;
        }
        else if (visibilityArray.Length == 480) 
        {
            anotherCount = 99;
        }
        
        int count = anotherCount;
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
