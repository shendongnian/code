	static class Extensions
	{
		public static IEnumerable<T> Merge<T>(this IEnumerable<IEnumerable<T>> source)
		{
			var queue = new Queue<IEnumerator<T>>();
			IEnumerator<T> itemEnumerator = null;
			try
			{
				// First pass: yield the first element (if any) and schedule the next (if any)
				foreach (var list in source)
				{
					itemEnumerator = list.GetEnumerator();
					if (!itemEnumerator.MoveNext())
						itemEnumerator.Dispose();
					else
					{
						yield return itemEnumerator.Current;
						if (itemEnumerator.MoveNext())
							queue.Enqueue(itemEnumerator);
						else
							itemEnumerator.Dispose();
					}
				}
				// Second pass: yield the current element and schedule the next (if any)
				while (queue.Count > 0)
				{
					itemEnumerator = queue.Dequeue();
					yield return itemEnumerator.Current;
					if (itemEnumerator.MoveNext())
						queue.Enqueue(itemEnumerator);
					else
						itemEnumerator.Dispose();
				}
			}
			finally
			{
				if (itemEnumerator != null) itemEnumerator.Dispose();
				while (queue.Count > 0) queue.Dequeue().Dispose();
			}
		}
	}
