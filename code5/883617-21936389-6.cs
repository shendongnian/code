    private async Task<string[]> ReadAllLinesAsync(string filePath)
    {
        ArrayList allLines = new ArrayList();
        using ( var streamReader = new StreamReader(File.OpenRead(filePath)) )
        {
            string line = await streamReader.ReadLineAsync();
            allLines.Add(line);
        }
        return (string[]) allLines.ToArray(typeof(string));
    }
