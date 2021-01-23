    if (lines[i].Trim() == string.Empty) 
        continue;
    string[] split = lines[i].Split('|');
    if (split.Length != 2)
        throw new InvalidOperationException("invalid file");
    string title = split[0];
    string times = split[1];
