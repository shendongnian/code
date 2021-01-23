    var lines = File.ReadAllLines(path);
    int[,] map = new int[fileLines.Length, 25];
    for (int i = 0; i < fileLines.Length; ++i)
    {
        var data = lines[i].Split(',').Select(c => Convert.ToInt32(c)).ToList();
        for(int j =0; j<25; ++j)
           map[i,j] = data[j];
    }
    return map;
