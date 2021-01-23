    var result = new List<string>();
    foreach (string line in cssLines)
    {
        string prefix = "url(\"";
        string postfix = ".png)";
        int startPosition = line.IndexOf(prefix);
        int endPosition = line.IndexOf(postfix);
        if (startPosition != -1 && endPosition != -1)
        {
            //replace urls
            string newLine = line.Substring(0, startPosition) + prefix + newUrl 
                + postfix + line.Substring(endPosition + posfix.Length);
            result.Add(newLine)
        }
    }
