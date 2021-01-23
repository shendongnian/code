    HashSet<string> Words = new HashSet<string>();
    foreach (string line in File.ReadLines(sourcePath))
    {
        int wordStart = 0;
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (c == ' ')
            {
                Words.Add(line.Substring(wordStart, i - wordStart).Trim().ToLower());
                wordStart = i + 1;
            }
        }
        if (wordStart < line.Length)
        {
            Words.Add(line.Substring(wordStart, line.Length - wordStart).Trim().ToLower());
        }
    }
    WordsDist = Words.OrderBy(word => word).ToArray();
    File.WriteAllLines("output.txt", WordsDist);
