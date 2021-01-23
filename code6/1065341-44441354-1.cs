    public static IEnumerable<TInner> TrySelect<TElement, TInner>(this IEnumerable<TElement> sequence, Func<TElement, TInner> selector)
	{
		TInner current = default(TInner);
		foreach (var element in sequence)
		{
			try { current = selector(element); }
			catch { continue; }
			yield return current;
		}
	}
	Process
	   .GetProcesses()
	   .TrySelect(p => p.MainModule.FileName)
