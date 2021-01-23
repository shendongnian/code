    public int GetLineNumber(string pathToFile, string content)
    {
        int lineNumber = 0;
        foreach (var line in File.ReadAllLines(pathToFile))
        {
             lineNumber++;
             if(line.Contains(content))
             {
                 return lineNumber;
             }
        }
        return lineNumber;
    }
