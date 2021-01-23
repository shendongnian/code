    var numbers = new[] {2, 3}.Union(Enumerable.Range(2, (int) (i*(Math.Log(i) + Math.Log(Math.Log(i)) - 0.5)))
                                               .AsParallel()
                                               .WithDegreeOfParallelism(Environment.ProcessorCount)
                                               // 8 cores on my machine
                                               .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                                               .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                                               // remove order dependancy
                                               .Where(x => Enumerable.Range(2, (int) Math.Ceiling(Math.Sqrt(x)))
                                                                     .All(y => x%y != 0))
                                               .TakeWhile((n, index) => index < i))
                              .ToList();
