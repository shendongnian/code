    var latterList = new List<LetterInfo>();
    var dict = new Dictionary<char, int>();
    for (int i = 0; i < letters.Length; i++)
    {
        char c = letters[i];
        int occ = 0;
        dict.TryGetValue(c, out occ);
        dict[c] = ++occ;
        var li = new LetterInfo { Letter = c, Index = i, Occurence = occ };
        latterList.Add(li);
    }
    letterInfos = latterList.ToArray();
