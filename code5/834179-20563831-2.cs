    for (int i = 0; i < rep.Count; i++)
    {
        string[] copy = (string[])RefineSelection.Clone();
        string hfSizeID = "foo" + i;
        string[] serRefine = copy;
        Console.WriteLine(string.Join(",", copy));
        serRefine[4] = hfSizeID;
        Console.WriteLine(string.Join(",", copy));
    }
