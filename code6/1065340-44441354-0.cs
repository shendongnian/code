	public static IEnumerable<TElement> WhereSafe<TElement, TInner>(this IEnumerable<TElement> sequence, Func<TElement, TInner> selector)
	{
		foreach (var element in sequence)
		{
			try { selector(element); }
			catch { continue; }
			yield return element;
		}
	}
    Process
        .GetProcesses()
        .WhereSafe(p => p.MainModule)
	    .Select(p => p.MainModule.FileName)
