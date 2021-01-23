    public static T[,] ToSquare2D<T>(this T[] array, int size)
    {
        var buffer = new T[(int)Math.Ceiling((double)array.Length/size), size];
        for (var i = 0; i < (float)array.Length / size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                buffer[i, j] = array[i + j];
            }
        }
        return buffer;
    }
