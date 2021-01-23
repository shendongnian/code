    public void writeLines(string filePath,string[] lines,int limit)
    {
        var buffer=File.ReadAllLines(path).Take(limit-lines.Length);
        File.WriteAllLines(filePath,lines);
        File.AppendAllLines(filePath,buffer);
    }
