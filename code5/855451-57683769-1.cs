csharp
static IReadOnlyList<IReadOnlyList<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
{
	var arrays = sequences.Select(s => s.ToArray()).ToArray();
	var numColumns = arrays.Length;
	if (numColumns == 0)
	{
		return new[]
        {
            Array.Empty<T>()
        };
	}
	var arrayLengths = arrays.Select(l => l.Length).ToArray();
	var arrayIndices = new int[numColumns];
	var numRows = arrayLengths.Aggregate((x, y) => x * y);
	var lastColumnIndex = numColumns - 1;
	var combinations = new IReadOnlyList<T>[numRows];
	for (var rowIndex = 0; rowIndex < numRows; rowIndex++)
	{
		var items = new T[numColumns];
		for (var columnIndex = 0; columnIndex < numColumns; columnIndex++)
		{
			items[columnIndex] = arrays[columnIndex][arrayIndices[columnIndex]];
		}
		combinations[rowIndex] = items;
		for (var i = lastColumnIndex; i >= 0; i--)
		{
			var updatedIndex = arrayIndices[i] = (arrayIndices[i] + 1) % arrayLengths[i];
			if (updatedIndex > 0)
			{
				break;
			}
		}
	}
	return combinations;
}
