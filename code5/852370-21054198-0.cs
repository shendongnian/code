    int iterationsPerThread = 10 * 1000000;
    var taskCount = Environment.ProcessorCount;
           
    int counter = 0;
    var tasks =
        Enumerable.Range(0, taskCount)
        .Select(_ => Task.Factory.StartNew(() =>
        {
            for (int i = 0; i < iterationsPerThread; i++)
            {
                counter = counter + 1; //racy!
            }
        }))
        .ToArray();
    Task.WaitAll(tasks); //quiece system
    Console.WriteLine("Expected: " + (iterationsPerThread * taskCount));
    Console.WriteLine("Actual: " + counter);
