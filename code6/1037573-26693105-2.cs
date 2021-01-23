    int width = binaryzacja.GetLength(0);
    int height = binaryzacja.GetLength(1);
    
    int newWidth = width;
    int newHeight = height;
    
    int[] keepRows = new int[height];
    int[] keepColumns = new int[width];
    
    int x, y, x2, y2;
    int i;
    
    for (i = y = 0; y < height; y++)
    {
        if (IsRowEmpty(binaryzacja, y)) newHeight--;
        else
        {
            keepRows[i] = y;
            i++;
        }
    }
    
    for (i = x = 0; x < width; x++)
    {
        if (IsColumnEmpty(binaryzacja, x)) newWidth--;
        else
        {
            keepColumns[i] = x;
            i++;
        }
    }
    
    int[,] binaryzacja2 = new int[newWidth, newHeight];
    
    // copy to new array
    for (y2 = y = 0; y < height; y++)
    {
        if(y == keepRows[y2])
        {
            for (x2 = x = 0; x < width; x++)
            {
                if(x == keepColumns[x2])
                {
                    binaryzacja2[x2, y2] = binaryzacja[x, y];
                    x2++;
                }
            }
            y2++;
        }
    }
