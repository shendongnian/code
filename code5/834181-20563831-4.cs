    string[] RefineSelection = new[] {"A", "B", "C", "D", "E" };
    for (int i = 1; i <= 3; i++)
    {
        string[] serRefine = RefineSelection;  // you're not creating a copy but you're referencing the session-array
        string hfSizeID = "foo" + i;
        Console.WriteLine(string.Join(",", RefineSelection));
        serRefine[4] = hfSizeID;
        Console.WriteLine(string.Join(",", RefineSelection));
    }
