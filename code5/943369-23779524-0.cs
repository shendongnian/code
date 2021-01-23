    private void thisIsMethodA()
    {
        //Vertical database
        Dictionary<int, Bitmap> verticalDB = new Dictionary<int, Bitmap>();
        // for each item
        Parallel.ForEach (vertocalDB, (entry) => 
        {
            // We call the depth first search method 
            dfsPruning(prefix, entry.Value, frequentItems, frequentItems, entry.Key, 2);
        }
    }
    private void dfsPruning(Prefix prefix, Bitmap prefixBitmap, List<int> sn, List<int> inl, int hasToBeGreaterThanForIStep, int m)
    {
        int maximumPatternLength = 100;
        Parallel.For(0,sn.Count,  new ParallelOptions { MaxDegreeOfParallelism = 10 }, (k) =>
        {
            if (maximumPatternLength > m)
            {
                dfsPruning(prefixSStep, newBitmap, sTemp, sTemp, item, m + 1);
            }
        });
        Parallel.For(0,inl.Count, new ParallelOptions { MaxDegreeOfParallelism = 10 }, (k) => 
        {
            if (maximumPatternLength > m)
            {
                dfsPruning(prefixIStep, newBitmap, sTemp, iTemp, item, m + 1);
            }
        });
    }
