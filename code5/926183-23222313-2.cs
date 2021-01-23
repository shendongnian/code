    c = new List<int>(a.Count + b.Count);
    int max = Math.Max(a.Count, b.Count);
    int aMax = a.Count;
    int bMax = b.Count;
    for (int i = 0; i < max; i++)
    { 
        if(i < aMax)
            c.Add(a[i]);
        if(i < bMax)
            c.Add(b[i]);
    }
