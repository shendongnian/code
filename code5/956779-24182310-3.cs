    using System;
    using System.Collections.Generic;
    using System.Linq;
    ...
	
	public static IEnumerable<TResult> Zip<T, TResult>(
		    this IEnumerable<T> source,
		    Func<IList<T>, TResult> resultSelector,
		    params IEnumerable<T>[] others)
	{
		if (resultSelector == null)
		{
			throw new ArgumentNullException("resultSelector");
		}
		var enumerators = new List<IEnumerator<T>>(others.Length + 1);
		enumerators.Add(source.GetEnumerator());
		enumerators.AddRange(others.Select(e => e.GetEnumerator()));
		try
		{
			var buffer = new T[enumerators.Count];
			while (true)
			{
				for (var i = 0; i < enumerators.Count; i++)
				{
					if (!enumerators[i].MoveNext())
					{
						yield break;
					}
					buffer[i] = enumerators[i].Current;
				}
				yield return resultSelector(buffer);
			}
		}
		finally
		{
			foreach (var enumerator in enumerators)
			{
				enumerator.Dispose();
			}
		}
	}
