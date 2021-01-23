    public IEnumerable<int?> ProcessSequence(IEnumerable<int?> seq)
    {
	int nullCount = 0;
	foreach(var x in seq)
	{
		if (x == null)
		{
			nullCount++;
		}
		else if (nullCount > 0)
		{
			nullCount++;
			var mid = x / nullCount;
			for (var i = 0; i<nullCount; i++)
			{
				yield return mid;
			}
			nullCount = 0;
		}		
		else
		{
			yield return x;
		}
	}
    }
