	/// <summary>
	/// Divides an enumeration into smaller (same-sized) chunks.
	/// </summary>
	/// <typeparam name="T">The type of the elements within the sequence.</typeparam>
	/// <param name="source">The sequence which should be breaked into chunks.</param>
	/// <param name="size">The size of each chunk.</param>
	/// <returns>An IEnumerable&lt;T&gt; that contains an IEnumerable&lt;T&gt; for each chunk.</returns>
	public static IEnumerable<IEnumerable<T>> Chunkify<T>(this IEnumerable<T> source, int size)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (size < 1)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		return ChunkifyImpl(source, size);
	}
	private static IEnumerable<IEnumerable<T>> ChunkifyImpl<T>(IEnumerable<T> source, int size)
	{
		using (var iter = source.GetEnumerator())
		{
			while (iter.MoveNext())
			{
				var chunk = new List<T>(size);
				chunk.Add(iter.Current);
				for (int i = 1; i < size && iter.MoveNext(); i++)
				{
					chunk.Add(iter.Current);
				}
				yield return chunk;
			}
		}
	}
