    var target = new string[var1, var2];
    var listlist = new List<List<string>>();
    for (int x = 0; x < target.GetLength(0); x++)
    {
        var newlist = new List<string>();
        for (int y = 0; y < target.GetLength(1); y++)
        {
            newlist.Add(target[x, y]);
        }
        listlist.Add(newlist);
    }
