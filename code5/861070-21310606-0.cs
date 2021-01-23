    /// <summary>
    /// Converts a generic <see cref="T:System.Collections.Generic.IEnumerable`1"/> to a generic <see cref="T:System.Linq.IQueryable`1"/>.
    /// </summary>
    /// 
    /// <returns>
    /// An <see cref="T:System.Linq.IQueryable`1"/> that represents the input sequence.
    /// </returns>
    /// <param name="source">A sequence to convert.</param><typeparam name="TElement">The type of the elements of <paramref name="source"/>.</typeparam><exception cref="T:System.ArgumentNullException"><paramref name="source"/> is null.</exception>
    [__DynamicallyInvokable]
    public static IQueryable<TElement> AsQueryable<TElement>(this IEnumerable<TElement> source)
    {
      if (source == null)
        throw System.Linq.Error.ArgumentNull("source");
      if (source is IQueryable<TElement>)
        return (IQueryable<TElement>) source;
      else
        return (IQueryable<TElement>) new EnumerableQuery<TElement>(source);
    }
