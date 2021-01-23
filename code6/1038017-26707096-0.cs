    /// <summary>
    /// Writes the contents of the array to the console
    /// </summary>
    private static void DisplayArray()
    {
        if (ArrayIsNullOrEmpty()) throw new Exception("Array is Empty");
        Console.WriteLine("Values currently in array: {0}", string.Join(", ", values));
    }
    /// <summary>
    /// Adds the integer to the beginning of the array and moves
    /// everything else to the next index
    /// </summary>
    /// <param name="firstValue">The integer to add</param>
    private static void AddFirst(int firstValue)
    {
        // First remove the last item (this will clear a space in the first position)
        RemoveLast();
        // Then update the first item
        values[0] = firstValue;
    }
    /// <summary>
    /// Removes the first item from the array, 
    /// moves all other items to the index before them, 
    /// and initializes the last item to zero
    /// </summary>
    public static void RemoveFirst()
    {
        if (ArrayIsNullOrEmpty()) throw new Exception("Array is Empty");
        // Move each item to the index before it
        for (int i = 0; i < values.Length - 1; i++)
        {
            values[i] = values[i + 1];
        }
        // Set the last item to zero
        values[values.Length - 1] = 0;
    }
    /// <summary>
    /// Removes the last item from the array, 
    /// moves all other items to the index after them, 
    /// and initializes the first item to zero
    /// </summary>
    public static void RemoveLast()
    {
        if (ArrayIsNullOrEmpty()) throw new Exception("Array is Empty");
        // Move each item to the previous index. Note that we have to start with the last
        // item and work our way forward, or else we overwrite a value before we move it 
        for (int i = values.Length - 1; i > 0; i--)
        {
            values[i] = values[i - 1];
        }
        // Set the first item to zero
        values[0] = 0;
    }
    /// <summary>
    /// Checks if the array is null or empty
    /// </summary>
    /// <returns>True if array is null or empty, otherwise false</returns>
    public static bool ArrayIsNullOrEmpty()
    {
        return (values == null || values.Length == 0);
    }
