    List<string> inputList = new List<string>();
    List<string> outputList = new List<string>();
    
    for (int i = 0; i < inputList.Count; i += 2) // assumes an even number of elements
    {
        if (i == inputList.Count - 1)
            outputList.Add(inputList[i]); // add single value
            // OR use the continue or break keyword to do nothing if you want to ignore the uneven value.
        else
            outputList.Add(inputList[i] + inputList[i+1]); // add two values as a concatenated string
    }
