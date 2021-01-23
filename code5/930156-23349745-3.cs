    string[] lines = { "blablabla  12:10:40 I want to remove this", "blablabla some more", "even more bla  ", "14:22:11" };
    foreach(string line in lines)
    {
        string newLine = SubstringBeforeTime(line, "HH:mm:ss");
        Console.WriteLine(string.IsNullOrEmpty(newLine) ? "<empty>" : newLine);
    }
