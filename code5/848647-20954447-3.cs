    var combinedCoords = new List<List<int>>();
    foreach(var c in coords)
    {
        var merge = new List<List<int>>();
        foreach(var g in combinedCoords)
        {
            if (c.Any(g.Contains))
            {
                merge.Add(g);
            }
        }
    
        if (merge.Count == 0)
        {
            combinedCoords.Add(c);
        }
    	
        merge.Add(c);
        for(int i = 1; i < merge.Count; i ++)
        {
            foreach(var v in merge[i].Except(merge[0]))
            {
                merge[0].Add(v);
            }
    
            combinedCoords.Remove(merge[i]);
        }
    }
