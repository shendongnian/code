    for (int i = 0; i < rep.Count; i++)
    {
        string[] copy = (string[])RefineSelection.Clone();
        string hfSizeID = "foo" + i;
        Console.WriteLine(string.Join(",", copy));
        copy[4] = hfSizeID;
        Console.WriteLine(string.Join(",", copy));
    }
