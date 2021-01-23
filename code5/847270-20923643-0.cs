    /// <summary>
    /// Determines if <paramref name="source"/> contains all elements present in <paramref name="elements"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the collections.</typeparam>
    /// <param name="source">The source collection.</param>
    /// <param name="elements">The collection elements to test for in <paramref name="source"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="source"/> contains all elements in <paramref name="elements"/>; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">
    /// <para>If <paramref name="source"/> is <see langword="null"/>.</para>
    /// <para>-or-</para>
    /// <para>If <paramref name="elements"/> is <see langword="null"/>.</para>
    /// </exception>
    public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<T> elements)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (elements == null)
            throw new ArgumentNullException("elements");
        return elements.Except(source).Any();
    }
