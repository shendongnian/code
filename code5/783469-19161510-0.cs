    List<string> inputList = new List<string>();
    List<string> outputList = new List<string>();
    
    for (int i = 0; i < inputList.Count; i += 2) // assumes an even number of elements
    {
        outputList.Add(inputList[i] + inputList[i+1]);
    }
