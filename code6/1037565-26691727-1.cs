    var list = new List<List<int>>();
    for (var i = 0; i < binary.GetLength(0); i++ )
    {
        var row = new List<int>();
        for(var j = 0; j < binary.GetLength(1); j++)
        {
            row.Add(binary[i, j]);
        }
        list.Add(row);
    }
