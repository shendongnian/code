	private static int GetMaxIndex2(byte[,] TwoDArray) {
		return ParallelEnumerable.Range(0, TwoDArray.GetLength(0))
		                         .Select(
			                         x => new {
				                         Index = x,
				                         Count = Enumerable.Range(0, TwoDArray.GetLength(1)).Count(y => TwoDArray[x, y] == 1)
			                         })
		                         .OrderByDescending(x => x.Count)
		                         .First()
		                         .Index;
	}
