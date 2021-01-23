    public  static string[] ReadFromFile(string filePath, int count, ref int lineCount)
    {
        lineCount += count;
        return File.ReadLines(filePath).Skip(lineCount).Take(count).ToArray();
    }
    private static int lineCount = 0;
    private static void Main(string[] args)
    {
       // read first ten line
       string[] lines = ReadFromFile("sample.txt", 10, ref lineCount);
       // read next 30 lines
       string[] otherLines = ReadFromFile("sample.txt", 30, ref lineCount)
    }
