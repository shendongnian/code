    public double[, ,] Mix(double[] weights, double gain)
    {
        int w, h;
        w = normalMaps[0].GetLength(0);
        h = normalMaps[0].GetLength(1);
    
        double[, ,] ret = new double[w, h, 3];
        int normcount = normalMaps.Count;
    
        //for (int y = 0; y < h; y++)
        Parallel.For(0, w, x =>            
        {
            for (int y = 0; y < h; y++)
            {
               .
               .
               .
            }
        });
    
        return ret;
    }
