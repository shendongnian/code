    string str = "OWERFLOW";
    char[] array = str.ToCharArray();
    char[] array2 = RemveFromArray(array, 'R');
    char[] array3 = InsertIntoArray(array2, 'T', 3);
    char[] array4 = RemveFromArrayAt(array, 3);
    static char[] RemveFromArray(char[] source, char value)
    {
        if (source == null)
            return null;
        char[] result = new char[source.Length];
        int resultIdx = 0;
        for (int ii = 0; ii < source.Length; ii++)
        {
            if(source[ii] != value)
                result[resultIdx++] = source[ii];
        }
        return result.Take(resultIdx).ToArray();
    }
    static char[] InsertIntoArray(char[] source, char value, int insertAt)
    {
        if (source == null || insertAt > source.Length)
            return null;
        char[] result = new char[source.Length + 1];
        Array.Copy(source, result, insertAt);
        result[insertAt] = value;
        Array.Copy(source, insertAt, result, insertAt + 1, source.Length - insertAt);
        return result;
    }
    static char[] RemveFromArrayAt(char[] source, int removeAt)
    {
        if (source == null || removeAt > source.Length)
            return null;
        char[] result = new char[source.Length - 1];
        Array.Copy(source, result, removeAt);
        Array.Copy(source, removeAt + 1, result, removeAt, source.Length - removeAt - 1);
        return result;
    }
