    Parallel.For(0, iScenarios, Enumerable.Empty<double>(),
        (int k, ParallelLoopState state, IEnumerable<double> localResults) =>
        {
            List<double> CalcResults = new List<double>();
            for (int n = iStart; n < iEnd; n++)
            {
                CalcResults.AddRange(CalcRoutine(n, k));
            }
            return localResults.Concat(this.SumOfResults(CalcResults));                   
        },
         (IEnumerable<double> localResults) =>
         {                    
             lock (locker)
            {
                 TotalResults.AddRange(localResults);
             }
         });
