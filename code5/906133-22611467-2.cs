    string[] lines = File.ReadAllLines(path);
    for(int i = 0; i < lines.Length; i++)
    {
        string line = lines[i];
        string[] tokens = line.Split(new char[]{'-', ' '});
        int number = int.Parse(tokens[0]);
        string text = tokens[1];
        lines[i] = number + "-" + text;
    }
    
    File.WriteAllLines(path2, lines);
