    public static void Main()
    {
        string dir = @"C:\tem";
        var directory = new DirectoryInfo(dir);
        FileInfo[] files = directory.GetFiles("*.bmp");
       var sortedFiles=files.ToDictionary(k=>GetIntValueFromString(k.Name),v=>v).OrderBy(entry=>entry.Key);
       foreach (var file in sortedFiles)
        {
            Console.WriteLine(file.Value.Name);
        }
        Console.Read();
    }
    static int GetIntValueFromString(string input)
    {
        var result = 0;
        var intString = Regex.Replace(input, "[^0-9]+", string.Empty);
        Int32.TryParse(intString, out result);
        return result;
    }
