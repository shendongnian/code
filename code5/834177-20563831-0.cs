    string[] RefineSelection = new[] {"A", "B", "C", "D", "E" };
    for (int i = 1; i <= 3; i++)
    {
        string hfSizeID = "foo" + i;
        string[] serRefine = RefineSelection;  // this is your Session-Array
        Console.WriteLine(string.Join(",", RefineSelection));
        serRefine[4] = hfSizeID;
        Console.WriteLine(string.Join(",", RefineSelection));
    }
