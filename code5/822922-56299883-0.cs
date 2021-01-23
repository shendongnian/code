    public readonly struct ConnectivityData
    {
        public readonly int[] N;
        public readonly int NumNeighbors;
        public readonly int NumChanges;
        public ConnectivityData(in int[] n, in int numNeighbors, in int numChanges)
        {
            N = n;
            NumNeighbors = numNeighbors;
            NumChanges = numChanges;
        }
    }
    public static void ZhangSuen(in HashSet<Pixel> pixels)
    {        
        while (true)
        {
            // Pass #1:
            List<Pixel> mark1 = new List<Pixel>();
            foreach (Pixel p in pixels)
            {
                ConnectivityData conn = ComputeConnectivity(p, pixels);
                if (conn.NumNeighbors > 1 && 
                    conn.NumNeighbors < 7 && 
                    conn.NumChanges == 1 &&
                    conn.N[0] * conn.N[2] * conn.N[4] == 0 &&
                    conn.N[2] * conn.N[4] * conn.N[6] == 0)
                {
                    mark1.Add(p);
                }
            }
            //delete all marked:
            foreach (Pixel p in mark1)
            {
                pixels.Remove(p);
            }
            // PASS #2:
            List<Pixel> mark2 = new List<Pixel>();
            foreach (Pixel p in pixels)
            {
                ConnectivityData conn = ComputeConnectivity(p, pixels);
                if (conn.NumNeighbors > 1 &&
                    conn.NumNeighbors < 7 &&
                    conn.NumChanges == 1 &&
                    conn.N[0] * conn.N[2] * conn.N[6] == 0 &&
                    conn.N[0] * conn.N[4] * conn.N[6] == 0)
                {
                    mark2.Add(p);
                }
            }
            //delete all marked:
            foreach (Pixel p in mark2)
            {
                pixels.Remove(p);
            }
            if (mark1.Count == 0 && mark2.Count == 0)
            {
                break;
            }
        }
            
    }
    private static ConnectivityData ComputeConnectivity(
        in Pixel p, 
        in HashSet<Pixel> pixels)
    {
        // calculate #neighbors and number of changes:
        int[] n = new int[8];
        if (pixels.Contains(new Pixel(p.X, p.Y - 1)))
        {
            n[0] = 1;
        }
        if (pixels.Contains(new Pixel(p.X + 1, p.Y - 1)))
        {
            n[1] = 1;
        }
        if (pixels.Contains(new Pixel(p.X + 1, p.Y)))
        {
            n[2] = 1;
        }
        if (pixels.Contains(new Pixel(p.X + 1, p.Y + 1)))
        {
            n[3] = 1;
        }
        if (pixels.Contains(new Pixel(p.X, p.Y + 1)))
        {
            n[4] = 1;
        }
        if (pixels.Contains(new Pixel(p.X - 1, p.Y + 1)))
        {
            n[5] = 1;
        }
        if (pixels.Contains(new Pixel(p.X - 1, p.Y)))
        {
            n[6] = 1;
        }
        if (pixels.Contains(new Pixel(p.X - 1, p.Y - 1)))
        {
            n[7] = 1;
        }
        return new ConnectivityData(
                n,
                n[0] + n[1] + n[2] + n[3] + n[4] + n[5] + n[6] + n[7],
                ComputeNumberOfChanges(n));
    }
    private static int ComputeNumberOfChanges(in int[] n)
    {
        int numberOfChanges = 0;
        // Iterate over each location and see if it is has changed from 0 to 1:
        int current = n[0];
        for (int i = 1; i < 8; i++)
        {
            if (n[i] == 1 && current == 0)
            {
                 numberOfChanges++;
            }
            current = n[i];
        }
        // Also consider the change over the discontinuity between n[7] and n[0]:
        if (n[0] == 1 && n[7] == 0)
        {
            numberOfChanges++;
        }
        return numberOfChanges;
    }
