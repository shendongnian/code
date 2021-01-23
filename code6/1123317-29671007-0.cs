    private void ParseWikiTable(string input, string newLineReplacement = " ")
    {
        string separatorHeader = "||";
        string separatorRow = "| |";
        string separatorElement = "|";
        input = Regex.Replace(input, @"[ \\]{2,}", newLineReplacement);
        string inputHeader = input.Substring(0, input.LastIndexOf(separatorHeader));
        string inputContent = input.Substring(input.LastIndexOf(separatorHeader) + separatorHeader.Length);
        string[] headerArray = SimpleSplit(inputHeader, separatorHeader);
        string[][] rowArray = SimpleSplit(inputContent, separatorRow).Select(r => SimpleSplit(r, separatorElement)).ToArray();
        // do something with output data
        TestPrint(headerArray);
        foreach (var r in rowArray) { TestPrint(r); }
    }
    private string[] SimpleSplit(string input, string separator, bool trimWhitespace = true)
    {
        input = input.Trim();
        if (input.StartsWith(separator)) { input = input.Substring(separator.Length); }
        if (input.EndsWith(separator)) { input = input.Substring(0, input.Length - separator.Length); }
        string[] segments = input.Split(new string[] { separator }, StringSplitOptions.None);
        if (trimWhitespace)
        {
            for (int i = 0; i < segments.Length; i++)
            {
                segments[i] = segments[i].Trim();
            }
        }
        return segments;
    }
    private void TestPrint(string[] lst)
    {
        string joined = "[" + String.Join("::", lst) + "]";
        Console.WriteLine(joined);
    }
