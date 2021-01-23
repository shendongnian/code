    public void writeLines(string filePath,string[] lines,int limit)
    {
        var buffer=Enumerable.Empty<string>();
        if(File.Exists(filePath))
            buffer=File.ReadAllLines(path);
        File.WriteAllLines(filePath,lines);
        int range=limit-lines.Length+buffer.Count;
        File.AppendAllLines(filePath,buffer.Take(range));
    }
