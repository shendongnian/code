    public void CreateNewFolder()
    {
        string[] lines = File.ReadAllLines(stringFile, Encoding.UTF8);
        Array.Resize(ref lines, lines.Length + 1);
        lines[lines.Length - 1] = "Test";
        File.WriteAllLines(stringFile, lines, Encoding.UTF8);
    }
