    public static T CalculateWeekendReportsResult<T>(string dataFilPath, Action<string> action)
    {
        string newFile = CopyFile(dataFilPath);
    
        action(newFile);
    
        RemoveNotUsedFiles(dataFilPath, newFile);
    
        return ReadCalculations<T>(newFile);
    }
