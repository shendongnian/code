    public static int GetNextNumberWithParsing(string directoryPath)
    {
        var dirs = Directory.GetDirectories(directoryPath);
        var number = dirs.Select(r => int.Parse(r.Replace("Rain event ", ""))).Max();
        return number + 1;
    }
