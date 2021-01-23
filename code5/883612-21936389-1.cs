    public async Task<IEnumerable<Subject>> ReadAsync(string filePath)
    { // Doesn't exist!
        string[] subjectStrings = await File.ReadAllLinesAsync(filePath);
        return this.Parse(subjectStrings);
    }
