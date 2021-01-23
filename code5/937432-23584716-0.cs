    public static T NthLast<T>(this IEnumerable<T> source, int count)
	{
	    if (count < 0)
		    throw new ArgumentException("count must be >= 0");
			
		int i = 0;
		Queue<T> queue = new Queue<T>(count);
		
		using (var e = source.GetEnumerator())
		{
		    while (e.MoveNext())
			{
			    queue.Enqueue(e.Current);
				if (i++ > count)
				{
					queue.Dequeue();
				}
			}
			
			if (count >= i)
					throw new ArgumentException("count was greater than length");
		}
		return queue.Dequeue();
	}
