    /// <summary>
    /// Copies an array with rank 1 and any lower-bound
    /// into a single-dimensional zero-based array (SZ-array) with lower bound zero.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="array">The array to copy from.</param>
    /// <returns>The resulting SZ-array.</returns>
    public static T[] ToSZArray<T>(Array array)
    {
        if (array.Rank != 1)
            throw new ArgumentException("Expected array with rank 1.", "array");
        T[] dest = new T[array.Length];
        Array.Copy(array, dest, array.Length);
        return dest;
    }
