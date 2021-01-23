    // backwards loop because you're going to remove items via index
    for (int i = one.Count - 1; i >= 0; i--)
    {
        string s1 = one[i];
        if (s1 == toFind)
        {
            two.Add(toFind);
            one.RemoveAt(i);
        }
    }
