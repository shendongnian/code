    string input = "1001, 1003, 1005-1010";
    List<int> result = new List<int>();
    foreach (string part in input.Split(','))
    {
        int i = part.IndexOf('-');
        if (i == -1)
        {
            result.Add(int.Parse(part));
        }
        else
        {
            int min = int.Parse(part.Substring(0, i));
            int max = int.Parse(part.Substring(i + 1));
            result.AddRange(Enumerable.Range(min, max - min + 1));
        }
    }
