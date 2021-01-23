	public static class GenericCollectionExtensions
	{
		public sealed class CollectionConverter<TItem>
		{
			private readonly IEnumerable<TItem> _source;
			public CollectionConverter(IEnumerable<TItem> source)
			{
				_source = source;
			}
			public TCollection To<TCollection>()
				where TCollection : ICollection<TItem>, new()
			{
				var collection = new TCollection();
				foreach(var item in _source)
				{
					collection.Add(item);
				}
				return collection;
			}
		}
		public static CollectionConverter<T> Convert<T>(this IEnumerable<T> sequence)
		{
			return new CollectionConverter<T>(sequence);
		}
	}
