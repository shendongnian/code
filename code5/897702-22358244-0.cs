    public static void DoneWithCalculations()
    {
        // By removing your static reference to your dictionary you
        //  allow the GC to free the memory.
        output = null;
    }
