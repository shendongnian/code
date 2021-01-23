    private Task ProcessFile(string filePath, int numberOfWorkers)
    {
        var lines = File.ReadAllLines(filePath);
        const int numWorkers = 8;		
		
        var parallelOptions = new ParallelOptions {
            MaxDegreeOfParallelism = numWorkers
        };	
	
        return Task.Run(() => 
            Parallel.ForEach(lines, parallelOptions, ProcessFileLine));
    }
	
    private void ProcessFileLine(string line)
    {
        /* Your processing logic here */
        Console.WriteLine(line);
    }
