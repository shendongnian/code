    int ThreadNumber = Environment.ProcessorCount/2;
    int SS = Variables.PopSize / ThreadNumber;
    
    int numberOfTotalIterations = // I dont know what goes here.
 
    object lockDummy = new object();
    GeneticAlgorithm[] doneAlgorithms = Enumerable.Range(0, numberOfTotalIterations)
                                        .AsParallel() // Makes the whole thing running in parallel
    									.WithDegreeOfParallelism(ThreadNumber) // We dont need this line if you want the system to manage the number of parallel processings.
    									.Select(index=>
    {
        int startPos = index * SS;
        int endPos = startPos + SS;
        var algo = new GeneticAlgorithm(Population, NumSeq, SeqSize, MaxOffset, PopFit, Child, Instance, startPos, endPos);
        algo.RunGA();
        algo.ShowPopulation();
        return algo;
    })
    									.ToArray();
    				
    // So we sort algorithms by BestSol ascending and take the first one to determine the "best".					
    GeneticAlgorithm best = doneAlgorithms.OrderBy(algo => algo.BestSol).First();
    
    BestFit = best.Bestsol;
    BestAlign = best.TV.Debug;
    Variables.ResSave = best.TV.ResSave;
    Variables.NumSeq = best.TV.NumSeq;	
