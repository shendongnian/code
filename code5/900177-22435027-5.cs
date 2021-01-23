    public static void ReplaceElements<T>(this T[] array,
                                          Func<T, T> replacementFunction)
    {
        // TODO: Argument validation
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = replacementFunction(array[i]);
        }
    }
