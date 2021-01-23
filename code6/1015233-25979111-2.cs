	public class SortedCollection<T> : ICollection<T>
	{
		private readonly List<T> collection = new List<T>();
		// TODO: initializable:
		private readonly IComparer<T> comparer = Comparer<T>.Default;
		public void Add(T item)
		{
			if (Count == 0)
			{
				collection.Add(item);
				return;
			}
			int minimum = 0;
			int maximum = collection.Count - 1;
			while (minimum <= maximum)
			{
				int midPoint = (minimum + maximum) / 2;
				int comparison = comparer.Compare(collection[midPoint], item);
				if (comparison == 0)
				{
					return; // already in the list, do nothing
				}
				if (comparison < 0)
				{
					minimum = midPoint + 1;
				}
				else
				{
					maximum = midPoint - 1;
				}
			}
			collection.Insert(minimum, item);
		}
		public bool Contains(T item)
		{
			// TODO: potential optimization
			return collection.Contains(item);
		}
		public bool Remove(T item)
		{
			// TODO: potential optimization
			return collection.Remove(item);
		}
		public IEnumerator<T> GetEnumerator()
		{
			return collection.GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		public void Clear()
		{
			collection.Clear();
		}
		public void CopyTo(T[] array, int arrayIndex)
		{
			collection.CopyTo(array, arrayIndex);
		}
		public int Count { get { return collection.Count; } }
		public bool IsReadOnly { get { return false; } }
	}
