    string str = "LEQN";
    List<char> characters = str.ToCharArray().ToList();
    List<string> combinations = new List<string>();
    for (int i = 0; i < characters.Count; i++)
    {
        int combCount = 1;
        string comb = characters[i].ToString();
        combinations.Add(comb);
        for (int j = 1; j < characters.Count - 1; j++)
        {
            int k = i + j;
            if (k >= characters.Count)
            {
                k = k - characters.Count;
            }
            comb += characters[k];
            combinations.Add(comb);
            combCount++;
        }
    }
