    /// <summary>
    /// Runs a single algorithm and returns it
    /// </summary>
    private GeneticAlgorithm _runAlgorithmAndReturn(int index, int SS)
    {
        int startPos = index * SS;
        int endPos = startPos + SS;
        var algo = new GeneticAlgorithm(Population, NumSeq, SeqSize, MaxOffset, PopFit, Child, Instance, startPos, endPos);
        algo.RunGA();
        algo.ShowPopulation();
        return algo;
    }
