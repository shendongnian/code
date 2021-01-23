    int n = 0;
    while (n < list.Count)
    {
        List<string> everythingBetweenBraces = new List<string>();
        if (list[n].EndsWith("{");
        {
            n++;
            while (list[n] != "}");
            {
                everythingBetweenBraces.Add(list[n]);
                n++;
            }
            n++; // Don't forget to jump to the next line after }
        }
        ...
    }
