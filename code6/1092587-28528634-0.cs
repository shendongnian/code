    public double[,] methodOne(Dictionary<string, double> myInputOne, 
        List<double> myInputTwo, out List<double> intermediateResults)
    {
        intermediateResults= new List<double>();
        double[,] finalResults= new double[rows, cols];
    
        // Do some calculation using myInputOne and myInputTwo
    
        intermediateResults.Add(something);
    
        // Continue the calculation using also intermediateResults
        // store results in double[,] finalResults
    
        return results ;
    }
