    var random = new Random(Guid.NewGuid().GetHashCode());
    var skeleton = new StringBuilder();
    
    var findText = "BC";
    
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
    	var result = input.Replace(findText, replaceIteration);
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
    		input.Replace(findText, replaceIterations[i]);
    });
    
    stopWatch.Stop();
    Console.WriteLine("#2 parallel implementation with chunking - {0} milliseconds", stopWatch.ElapsedMilliseconds);
    
    
    // SMARTER IMPLEMENTATIOn - Builds indexed replacement table.
    stopWatch = Stopwatch.StartNew();
    var indexes = new List<int>();
    
    var startingPosition = 0;
    int currentPosition;
    
    while ((currentPosition = input.IndexOf(findText, startingPosition)) > 0)
    {
    	indexes.Add(currentPosition);
    	startingPosition = currentPosition + 1;
    }
    
    if(indexes[indexes.Count() - 1] != input.Count() - 1)
    	indexes.Add(input.Count() - 1);
    
    rangePartitioner = Partitioner.Create(0, replaceIterations.Count);
    Parallel.ForEach(rangePartitioner, (range, loopState) =>
    {
    	for (var i = range.Item1; i < range.Item2; i++)
    	{
    		var replaceWith = replaceIterations[i];
    		var finalResult = new StringBuilder(input.Length - (indexes.Count * findText.Length) + (replaceWith.Length * indexes.Count));
    
    		for (var j = 0; j < input.Length; j++)
    		{
    			if (indexes.BinarySearch(j) < 0)
    				finalResult.Append(input[j]);
    			else
    			{
    				finalResult.Append(replaceIterations[i]);
    				j += replaceIterations.Count;
    			}
    		}
    	}
    });
    
    stopWatch.Stop();
    Console.WriteLine("#3 parallel implementation with chunking & FAST INDEX scan - {0} milliseconds", stopWatch.ElapsedMilliseconds);
    
    
    Console.ReadLine();
