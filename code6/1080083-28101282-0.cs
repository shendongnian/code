    public static List<PointCollection> DoKMeans(PointCollection points, int clusterCount, Point[] startingCentres)
    {
        // code...
        int ctr = 0;
        foreach (List<Point> group in allGroups)
        {
            PointCollection cluster = new PointCollection();
            cluster.c.X = startingCentres[ctr].X;
            cluster.c.Y = startingCentres[ctr].Y;
            cluster.AddRange(group);
            allClusters.Add(cluster);
        }
        // rest of code the same
    }
