    int[] a = {1, 2, 3, 4, 5};
    int[] b = {2, 3};
    int count = 0;
    int bl = b.Length;
    for (int i = 0; i <= a.Length - bl; i++)
    {
        var suba = a.Skip(i).Take(bl);
        if (suba.SequenceEqual(b))
        count++;
    }
