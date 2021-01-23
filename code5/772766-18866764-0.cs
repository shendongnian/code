    var mapPoints = new Dictionary<int[], List<int[]>)(PointsEqualityComparer);
    
    for (int i = 0; i <this.Count; i++)
    {
        for (int j = 0; j < this[i].Count; j++)
        {
            foreach (var point in pointsLocal[i,j]) 
            {
                if (faultyData[i][j])
                {
                    // infected point
                    mapPoints[point] = null;  
                }
                else
                {
                    // Add the current sensor's indices (i,j) to the list of 
                    // known sensors for the current map point
                    List<int[]> sensors = null;
                    if (!mapPoints.TryGetValue(point, out sensors)) 
                    {
                        sensors = new List<int[]>();
                        mapPoints[point] = sensors;
                    }
                    // null here means that we previously determined that the
                    // current map point is infected 
                    if (sensors != null) 
                    {
                        // Add sensor to list for this map point
                        sensors.Add(new int[] { i, j });
                    }
                }
            }
        } 
    }
