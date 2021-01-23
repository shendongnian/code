    int int1, int2;
    HashSet<int> hs = new HashSet<int>();
    hs.Add(1);
    hs.Add(2);
    hs.Add(3);
    for (int i = 0; i < hs.Count-1; i++) {
        int1 = hs.ElementAt<int>(i);
        for (int j = i + 1; j < hs.Count; j++)
        {
            int2 = hs.ElementAt<int>(j);
        }
    }
