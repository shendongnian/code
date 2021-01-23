    public Results methodOne(Dictionary<string, double> myInputOne, List<double> myInputTwo)
    {
       var results = new Results();
       List<double> intermediateResults = new List<double>();
       double[,] finalResults = new double[rows, cols];
       // Do some calculation using myInputOne and myInputTwo
       intermediateResults.Add(something);
       // Continue the calculation using also intermediateResults
       // store results in double[,] finalResults
       results.FinalResult = finalResult;
       results.IntermediateResults = intermediateResults;
    
       return results;
    }
