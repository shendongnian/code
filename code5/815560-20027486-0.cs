    HashSet<string> Words = new HashSet<string>();
    List<char> tempChars = new List<char>();
    foreach (string line in ReadLines())
    {
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (c == ' ')
            {
                string word = new string(tempChars.ToArray()).Trim().ToLower();
                if (Words.Contains(word))
                    Words.Add(word);
            }
            else
            {
                tempChars.Add(c);
            }
        }
    }
    if (tempChars.Count > 0)
    {
        string word = new string(tempChars.ToArray()).Trim().ToLower();
        if (Words.Contains(word))
            Words.Add(word);
    }
    File.WriteAllLines("output.txt", Words.OrderBy(word => word));
