    string input = "1+1+1-2+2/2*4-2*3/23";
    
    //create a dictionary to store the results
    Dictionary<string, List<int>> results = new Dictionary<string, List<int>>();
    
    //add results for + symbol
    results.Add("+", GetAllIndices(input, "+"));
    
    //add results for - symbol
    results.Add("-", GetAllIndices(input, "-"));
    
    //you can then access all indices for a given symbol like so
    foreach(int index in results["+"])
    {
        //do something with index
    }
