    int h = array.GetLength(0), w = array.GetLength(1);
    for(int i = 0, j = 0, c = 1; i < h; i++, c = -c, j += c)
    {
        for(int k = 0; k < w; k++, j += c)
        {
            Console.WriteLine(array[i, j]);
        }
    }
