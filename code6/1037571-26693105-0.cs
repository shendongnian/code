    int width = binaryzacja.GetLength(0);
    int height = binaryzacja.GetLength(1);
    
    int newWidth = width;
    int newHeight = height;
    
    int x, y, x2, y2;
    
    for (y = 0; y < height; y++)
    {
        if (IsRowEmpty(binaryzacja, y)) newHeight--;
    }
    
    for (x = 0; x < width; x++)
    {
        if (IsColumnEmpty(binaryzacja, x)) newWidth--;
    }
    
    int[,] binaryzacja2 = new int[newWidth, newHeight];
    
    
    // copy to new array
    for (y2 = y = 0; y < height; y++)
    {
        if (!IsRowEmpty(binaryzacja, y))
        {
            for(x = x2 = 0; x < width; x++)
            {
                if (!IsColumnEmpty(binaryzacja, x))
                {
                    binaryzacja2[x2, y2] = binaryzacja[x, y];
                    x2++;
                }
            }
            y2++;
        }
    }
    
    
    
    bool IsRowEmpty(int[,] array, int y)
    {
        for (int x = 0; x < array.GetLength(0); x++)
        {
            if (array[x, y] != 0) return false;
        }
        return true;
    }
    
    bool IsColumnEmpty(int[,] array, int x)
    {
        for (int y = 0; y < array.GetLength(1); y++)
        {
            if (array[x, y] != 0) return false;
        }
        return true;
    }
