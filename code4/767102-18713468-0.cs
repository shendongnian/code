    // assume i1, i2 are sources and i3 is result
    int max = i1.Count>i2.Count?i1.Count:i2.Count;
    for (int i = 0; i < max; i++)
    {
        i3[i] = (i1.Count > i ? i1[i] : 0) + (i2.Count > i ? i2[i] : 0);
    }
    // another varient:
    for (int i = 0; i < i1.Count; i++)
    {
        i3[i] = i1[i] + (i2.Count > i ? i2[i] : 0);
    }
    for (int i = i1.Count; i < i2.Count; i++)
    {
        i3[i] = i2[i];
    }
