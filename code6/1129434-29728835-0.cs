    public static T[] RemoveRow<T>(T[] array, int row)
    {
        T[] array2 = new T[array.Length - 1];
        for (int i = 0; i < array.Length; i++)
        {
            if (i < row)
            {
                array2[i] = array[i];
            }
            else if (i > row)
            {
                array2[i - 1] = array[i];
            }
        }
        return array2;
    }
    public static T[][] RemoveColumn<T>(T[][] array, int column)
    {
        T[][] array2 = new T[array.Length][];
        for (int i = 0; i < array.Length; i++)
        {
            array2[i] = RemoveRow(array[i], column);
        }
        return array2;
    }
