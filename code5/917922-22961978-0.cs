    /// <summary>
    /// Replaces the content of a collection with the content of another collection.
    /// </summary>
    /// <typeparam name="TSource">The type of elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">The target data collection.</param>
    /// <param name="sourceCollection">The collection whose elements should be added to the System.Collections.Generic.ICollection&lt;T&gt;.</param>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <c>null</c>.</exception>
    public static void ReplaceContentWith<TSource>(this ICollection<TSource> source, IEnumerable<TSource> sourceCollection)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        source.Clear();
        source.AddRange(sourceCollection);
    }
