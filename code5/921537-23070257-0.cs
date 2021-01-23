    void Main()
    {
        string yourRootSolutionPath = @"D:\temp";
        foreach(string s in Directory.EnumerateFiles(yourRootSolutionPath, "*.cs", SearchOption.AllDirectories))
        {
            string[] lines = File.ReadAllLines(s);
            for(int x = 0; x < lines.Length; x++)
            {
                int pos = lines[x].IndexOf("---using");
                if(pos > 0)
                {
                    lines[x] = lines[x].Substring(0, pos+3) + Environment.NewLine + lines[x].Substring(pos+3);
                    File.WriteAllLines(s, lines);
                    break;
                }
            }
        }
    }
