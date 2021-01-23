		var random = new Random(Guid.NewGuid().GetHashCode());
		var skeleton = new StringBuilder();
		var replaceWhat = "BC";
		// build 2MB string.
		for (var i = 0; i < Math.Pow(10, 6) / 2; i++)
		{
			var randomNumber = random.Next(0, 3);
			var character = randomNumber == 0 ? 'A' : randomNumber == 1 ? 'B' : 'C';
			skeleton.Append(character);
		}
		var replaceIterations = new List<string>();
		for (var i = 0; i < 500; i++)
		{
			var randomNumber = random.Next(0, 3);
			var replaceIteration = randomNumber == 0 ? "AB" : randomNumber == 1 ? "BC" : "CD";
			replaceIterations.Add(replaceIteration);
		}
		var input = skeleton.ToString();
		GC.Collect();
		GC.WaitForPendingFinalizers();
		// NAIVE IMPLEMENTATIOn - REPLACE IN SINGLE THREAD
		var stopWatch = Stopwatch.StartNew();
		foreach (var replaceIteration in replaceIterations)
		{
			var result = input.Replace(replaceWhat, replaceIteration);
		}
		stopWatch.Stop();
		Console.WriteLine("#1 naive implementation - {0} milliseconds", stopWatch.ElapsedMilliseconds);
		// PARTITIONER IMPLEMENTATION - REPLACE IN MULTIPLE THREADS
		GC.Collect();
		GC.WaitForPendingFinalizers();
		stopWatch = Stopwatch.StartNew();
		var rangePartitioner = Partitioner.Create(0, replaceIterations.Count);
		Parallel.ForEach(rangePartitioner, (range, loopState) =>
		{
			for (var i = range.Item1; i < range.Item2; i++)
				input.Replace(replaceWhat, replaceIterations[i]);
		});
		stopWatch.Stop();
		Console.WriteLine("#2 parallel implementation with chunking - {0} milliseconds", stopWatch.ElapsedMilliseconds);
		// SMARTER IMPLEMENTATIOn - Builds indexed replacement table.
		GC.Collect();
		GC.WaitForPendingFinalizers();
		stopWatch = Stopwatch.StartNew();
		var indexes = new List<int>();
		var startingPosition = 0;
		int currentPosition;
		while ((currentPosition = input.IndexOf(replaceWhat, startingPosition)) >= 0)
		{
			indexes.Add(currentPosition);
			startingPosition = currentPosition + 1;
		}
		// todo; take care of indexes.Count==0.
		var replaceIterationsPartitioner = Partitioner.Create(0, replaceIterations.Count);
		Parallel.ForEach(replaceIterationsPartitioner, (outerRange, outerLoopState) =>
		{
			for(var g = outerRange.Item1; g < outerRange.Item2; g++)
			{
				var replaceWith = replaceIterations[g];
				var finalSize = input.Length - (indexes.Count*replaceWhat.Length) + (indexes.Count*replaceWith.Length);
				var finalResult = new StringBuilder(finalSize) {Length = finalSize};
				rangePartitioner = Partitioner.Create(0, indexes.Count);
				Parallel.ForEach(rangePartitioner, (innerRange, innerLoopState) =>
				{
					for (var i = innerRange.Item1; i < innerRange.Item2; i++)
					{
						var currentIndex = indexes[i];
						var prevIndex = i > 0 ? indexes[i - 1] : -replaceWhat.Length;
						var n = 0;
						if (prevIndex >= 0)
						{
							n = prevIndex + replaceWhat.Length;
							// note that due to offset changes,
							// prevIndex doesn't map to 1:1 if lens are different
							if (replaceWhat.Length != replaceWith.Length)
							{
								var offset = (replaceWhat.Length - replaceWith.Length) * i;
								var dir = replaceWhat.Length < replaceWith.Length;
								n = prevIndex + offset + replaceWith.Length + (dir ? 1 : -1);
							}
						}
						// append everything between two indexes.
						for (var k = prevIndex + replaceWhat.Length; k < currentIndex; k++)
							finalResult[n++] = input[k];
						// append replaced text.
						foreach (var ch in replaceWith)
							finalResult[n++] = ch;
						// if dealing with last index.
						// we need to append remaining parts
						if (currentIndex == indexes.Last())
						{
							for (var k = currentIndex + replaceWhat.Length; k < input.Length; k++)
								finalResult[n++] = input[k];
						}
					}
				});
			}
		});
		stopWatch.Stop();
		Console.WriteLine("#3 parallel implementation with chunking & FAST INDEX scan - {0} milliseconds", stopWatch.ElapsedMilliseconds);
		Console.ReadLine();
