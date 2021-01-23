    var output = new Dictionary<int, int>();
    foreach (var val in list)
    {
        if (!output.ContainsKey(val)) 
        {
            output.Add(val, 1);
        }
        else
        {
            output[val] = output[val] + 1;
        }
    }
