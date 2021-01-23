    IEnumerable<string> EnumerateSpecificFiles(
        string directory, string initialTextForFileName)
    {
        char[] initialCharacters =
            {
                char.ToLowerInvariant(initialTextForFileName[0]),
                char.ToUpperInvariant(initialTextForFileName[0])
            };
        foreach (char ch in initialCharacters)
        {
            foreach (string file in Directory.GetFiles(directory, ch + "*"))
            {
                if (file.StartsWith(initialTextForFileName, StringComparison.OrdinalIgnoreCase))
                {
                    yield return file;
                }
            }
        }
    }
