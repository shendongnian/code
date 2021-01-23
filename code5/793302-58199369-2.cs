    // ...
    foreach (var (IsDone, Index) in await Task.WhenAll(tasks))
    {
    	if (IsDone)
    	{
    		Console.WriteLine("Ending Process {0}", Index);
    	}
    }
    // ...
