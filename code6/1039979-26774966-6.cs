    var lines = new DicAsArray<string>();
    lines.Add("zero");
    lines.Add("one");
    lines.Add("two");
    lines.Add("three");
    lines.Add("four");
    lines.Crop();
    lines[2] = "!!!";
    for (int i = 0; i < lines.Count; i++)
    {
        Console.WriteLine(lines[i]);
    }
