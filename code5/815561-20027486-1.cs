    HashSet<string> Words = new HashSet<string>();
    List<char> tempChars = new List<char>();
    foreach (string line in ReadLines())
    {
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (c == ' ')
            {
                Words.Add(new string(tempChars.ToArray()).Trim().ToLower());
            }
            else
            {
                tempChars.Add(c);
            }
        }
    }
    if (tempChars.Count > 0)
    {
        Words.Add(new string(tempChars.ToArray()).Trim().ToLower());
    }
    File.WriteAllLines("output.txt", Words.OrderBy(word => word));
