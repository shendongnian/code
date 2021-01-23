    Parallel.For(0, iScenarios, () => new double[6],
        (int k, ParallelLoopState state, double[] localResults) =>
            {
                List<double> CalcResults = new List<double>();
                for (int n = iStart; n < iEnd; n++)
                {
                    CalcResults.AddRange(CalcRoutine(n, k));
                }
                localResults = this.SumOfResults(CalcResults)
                                   .Concat(localResults).ToArray();
                return localResults;                   
            },
             (double[] localResults) =>
             {                    
                 lock (locker)
                {
                     TotalResults.AddRange(localResults);
                 }
             });
