        public long CalculateFactorial(long value)
        {
            var result = 1L;
            var syncRoot = new object();
            checked
            {
                Parallel.For(
                    // always 1
                    1L,
                    // target value
                    value,
                    // if need more control, add { MaxDegreeOfParallelism = 4}
                    new ParallelOptions(),
                    // thread local result init
                    () => 1L,
                    // next value
                    (i, state, localState) => localState * i,
                    // aggregate local thread results
                    localState =>
                    {
                        lock (syncRoot)
                        {
                            result *= localState;
                        }
                    }
                    );                
            }
            return result;
        }
