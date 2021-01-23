    private static void Main(string[] args)
    {
        string s = @"<p>This is a text</p><span class=""cls"" style=""background-color: yellow"">This is another text</span>";
    
        var list = s.Split(new[] {"<"}, StringSplitOptions.RemoveEmptyEntries);
        foreach (var item in list)
            Console.Write(ClearAttributes('<' + item));
        Console.ReadLine();
    }
    
    private static string ClearAttributes(string source)
    {
        int startindex = source.IndexOf('<');
        int endindex = source.IndexOf('>');
        string tag = source.Substring((startindex + 1), (endindex - startindex - 1));
        int spaceindex = tag.IndexOf(' ');
        if (spaceindex > 0)
            tag = tag.Substring(0, spaceindex);
        return String.Concat('<', tag, source.Substring(endindex));
    }
