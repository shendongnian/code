    List<int> indexes = new List<int>();
    for (int i = 0; i < file.Length; i++)
    {
        if (file[i]==CharacterSearch)
        {
            indexes.Add(i);    
        }
    }
    int count = indexes.Count;
