    //EDIT - Create an array of length 0 here    V    for input to first iteration
    Parallel.For(0, iScenarios, () => new double[0],
        (int k, ParallelLoopState state, double[] localResults) =>
            {
                List<double> CalcResults = new List<double>();
                for (int n = iStart; n < iEnd; n++)
                {
                    CalcResults.AddRange(CalcRoutine(n, k));
                }
                localResults = localResults.Concat(
                                   this.SumOfResults(CalcResults)
                               ).ToArray();
                return localResults;                   
            },
             (double[] localResults) =>
             {                    
                 lock (locker)
                {
                     TotalResults.AddRange(localResults);
                 }
             });
