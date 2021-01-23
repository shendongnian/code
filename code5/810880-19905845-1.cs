    public void ProcessData(String rootDirectory, int batchSize) 
    {
        IEnumerable<string> pathsToProcess = GetPathsToProcess(rootDirectory);
        int currentBatch = 0;
        while (currentBatch*batchSize < pathsToProcess.Length) 
        {
            // take a subset of the paths to process
            IEnumerable<string> batch = pathsToProcess
                .Skip(currentBatch*batchSize)
                .Take(batchSize);
            DoYourDatabaseLogic(batch);
            currentBatch++;
        }
    }
