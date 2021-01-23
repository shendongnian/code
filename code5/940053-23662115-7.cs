    int ThreadNumber = Environment.ProcessorCount/2;
    int SS = Variables.PopSize / ThreadNumber;
    int numberOfTotalIterations = // I don't know what goes here.
    var doneAlgorithms = Enumerable.Range(0, numberOfTotalIterations)
                                   .AsParallel() // Makes the whole thing running in parallel
                                   .WithDegreeOfParallelism(ThreadNumber) // We don't need this line if you want the system to manage the number of parallel processings.
                                   .Select(index=> _runAlgorithmAndReturn(index,SS))
                                   .ToArray(); // This is obsolete if you only need the collection of doneAlgorithms to determine the best one.
                                               // If not, keep it to prevent multiple enumerations.
    // So we sort algorithms by BestSol ascending and take the first one to determine the "best".
    // OrderBy causes a full enumeration, hence the above mentioned obsoletion of the ToArray() statement.
    GeneticAlgorithm best = doneAlgorithms.OrderBy(algo => algo.BestSol).First();
    BestFit = best.Bestsol;
    BestAlign = best.TV.Debug;
    Variables.ResSave = best.TV.ResSave;
    Variables.NumSeq = best.TV.NumSeq;
