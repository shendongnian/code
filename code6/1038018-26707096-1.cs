    /// <summary>
    /// Writes the contents of the array to the console
    /// </summary>
    private static void DisplayArray()
    {
        ThrowIfArrayNullOrEmpty();
        Console.WriteLine("Values currently in array: {0}", string.Join(", ", values));
    }
    /// <summary>
    /// Adds the integer to the start of the array and everything else to the next index
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
    /// Moves all items to the index before them, and initializes the last item to zero
    /// </summary>
    public static void RemoveFirst()
    {
        ThrowIfArrayNullOrEmpty();
        // Move each item to the index before it
        for (int i = 0; i < values.Length - 1; i++)
        {
            values[i] = values[i + 1];
        }
        // Set the last item to zero
        values[values.Length - 1] = 0;
    }
    /// <summary>
    /// Moves all other to the next index and initializes the first item to zero
    /// </summary>
    public static void RemoveLast()
    {
        ThrowIfArrayNullOrEmpty();
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
    /// Throws an exception if the array is null or empty
    /// </summary>
    public static void ThrowIfArrayNullOrEmpty()
    {
        if (values == null) throw new Exception("Array is Null");
        if (values.Length == 0) throw new Exception("Array is Empty");
    }
