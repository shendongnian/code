    static void Parse(string inputFile)
    {
        // Lots of code goes in here
    }
    static void Parse(List<string> inputFileList)
    {
        foreach (var inputFile in inputFileList)
            Parse(inputFile);
    }
