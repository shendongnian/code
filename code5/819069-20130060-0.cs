    string str = "ABCD";
    List<char> characters = str.ToCharArray().ToList();
    List<string> combinations = new List<string>();
    for (int i = 0; i < characters.Count; i++)
    {
        int combCount = 1;
        string comb = characters[i].ToString();
        combinations.Add(comb);
        for (int j = 0; j < characters.Count; j++)
        {
                        
            if (i != j)
            {
                comb += characters[j];
                combinations.Add(comb);
            }
            combCount++;
            if (combCount == characters.Count - 1)
            {
                break;
            }
        }
    }
