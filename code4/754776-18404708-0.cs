    for (int k = allPointsWithInReach.Count<Point>()-1; k >= 0; k--)
    {
        Point p = allPointsWithInReach[k];
        foreach (var lP in list)
            if (lP.P == p)
                allPointsWithInReach.RemoveAt(k);
    }
