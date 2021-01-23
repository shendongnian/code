    public void Replace(string originalFile, string replacementsFile)
    {
        var originalContent = System.IO.File.ReadAllLines(originalFile);
        var replacements = System.IO.File.ReadAllLines(replacementsFile);
        foreach(var replacement in replacements)
        {
            var _split = replacement.Split(new char[] { '^' });
            var lineNumber = Int32.Parse(_split[0]);
            // checks if the original content file has that line number and replaces
            if (originalContent.Length < lineNumber)
                originalContent[lineNumber] = originalContent[lineNumber].Replace(_split[1], _split[2]);
        }
        System.IO.File.WriteAllLines(originalFile, originalContent);
    }
