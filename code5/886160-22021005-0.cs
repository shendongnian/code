    using MathNet.Numerics.Statistics;
    var data = new List<Tuple<string, double>>
    {
        Tuple.Create("A", 1.0),
        Tuple.Create("B", 2.0),
        Tuple.Create("C", 1.5)
    };
    
    // using the normal extension methods within `Statistics`
    var stdDev1 = data.Select(x => x.Item2).StandardDeviation();
    var mean1 = data.Select(x => x.Item2).Mean();
    
    // single pass variant (unfortunately there's no single pass MeanStdDev yet):
    var meanVar2 = data.Select(x => x.Item2).MeanVariance();
    var mean2 = meanVar2.Item1;
    var stdDev2 = Math.Sqrt(meanVar2.Item2);
    
    // directly using the `StreamingStatistics` class:
    StreamingStatistics.MeanVariance(data.Select(x => x.Item2));
