    void DoSomethingParallel()
    {
        ParallelOptions parOpts = new ParallelOptions();
        parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
        object[] objs = new object[10];
        Parallel.ForEach(objs, parOpts, currObj =>
        {
            Console.WriteLine("This is the current object: {0}", currObj.ToString());
        });
    }
