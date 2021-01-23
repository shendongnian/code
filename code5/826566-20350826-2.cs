    string currentInputToHandle = string.Join("", Environment.GetCommandLineArgs());   
    do
    {
        foreach(string singleArgument in currentInputToHandle.Split("-"))
        {
            HandleEnteredArgument(singleArgument);
        }
        
        currentInputToHandle = Console.ReadLine();
    }while(currentInputToHandle.ToLowerInvariant() != "exit".ToLowerInvariant())
