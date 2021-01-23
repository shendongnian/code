    public static string NextString(string textfind)
    {
        return File.ReadLines(FILENAME)
               .SkipWhile(line => !line.Contains(textfind))
               .Skip(1)
               .First();
    }
