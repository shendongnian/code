    string[] lines = File.ReadAllLines(path);
    foreach(string line in lines)
    {
        string[] tokens = line.Split(new char[]{'-'});
        int number = int.Parse(tokens[0]);
        string text = tokens[1];
        // ...
    }
    
    File.WriteAllLines(path2, lines);
