    string[] sentences = bodyText.Split(' ');
    List<string[]> parts = new List<string[]>();
    for (int i = 0; i < sentences.Length; i += 500)
    {
        parts.Add(sentences.Skip(i).Take(500).ToArray());
    }
