    for (int i = 0; i <this.Count; i++)
    {
        for (int j = 0; j < this[i].Count; j++)
        {
            var points = allPairsLocal[i][j];
            var cleanedUp = new List<int[]>();
            foreach (var point in points) 
            {
                // Important: do NOT use 'faultyPoints' here. It will kill performance
                if (mapPoints[point] != null)
                {
                   cleanedUp.Add(point); 
                }
            }
            allPairsLocal[i][j] = cleanedUp;   
        }
    }
