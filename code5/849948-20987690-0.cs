    List<string> full_lines = new List<string>();
    System.IO.StreamReader sr = new System.IO.StreamReader(path);
    string line = "";
    while(!sr.EndOfStream)
    {
        line = sr.ReadLine();
        if(!line.Contains("/"))
        {
            full_lines[full_lines.Count - 1] += line;
        }
        else
            full_lines.Add(line);
    }
