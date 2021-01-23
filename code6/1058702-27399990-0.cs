    List<ProcessInfo> processes = new List<ProcessInfo>();
    StreamReader reader = new StreamReader("input.txt');
    reader.ReadLine(); //The headers don't matter!
    
    string currentLine;
    while (currentLine = reader.ReadLine() != null)
    {
        ProcessInfo newInfo = new ProcessInfo();
        // String separation can be done if needed; Can use String.Split API
        processes.Add(newInfo);
    }
