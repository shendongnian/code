    /// <summary>Shallow clones an array.</summary>
    /// <typeparam name="T">The type of array elements.</typeparam>
    /// <param name="array">An array to clone.</param>
    /// <returns>The cloned array.</returns>
    /// <remarks>This is much faster than the built-in <see cref="Array.Clone"/> method.</remarks>
    public static T[] ShallowClone<T>(this T[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException("array");
        }
        T[] result = new T[array.Length];
        Array.Copy(array, result, array.Length);
        return result;
    }
