	/// <summary>
	/// The max number of parallel tasks
	/// </summary>
	static readonly int DegreeOfParallelism = Environment.ProcessorCount;
		
	public BigInteger Factorial(long x)
	{
		// Make as many parallel tasks as our DOP
		// And make them operate on separate subsets of data
		var parallelTasks =
			Enumerable.Range(1, DegreeOfParallelism)
				        .Select(i => Task.Factory.StartNew(() => Multiply(x, i),
                                     TaskCreationOptions.LongRunning))
						.ToArray();
		// after all tasks are done...
		Task.WaitAll(parallelTasks);
		// ... take the partial results and multiply them together
		BigInteger finalResult = 1;
		foreach (var partialResult in parallelTasks.Select(t => t.Result))
		{
			finalResult *= partialResult;
		}
		return finalResult;
	}
	/// <summary>
	/// Multiplies all the integers up to upperBound, with a step equal to DOP
	/// starting from a different int
	/// </summary>
	/// <param name="upperBoud"></param>
	/// <param name="startFrom"></param>
	/// <returns></returns>
	public BigInteger Multiply(long upperBoud, int startFrom)
	{
		BigInteger result = 1;
		for (var i = startFrom; i < upperBoud; i += DegreeOfParallelism)
			result *= i;
		return result;
	}
