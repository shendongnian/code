    public static void EnableOptimizations()
    {
        #if DEBUG
            BundleTable.EnableOptimizations = false;
        #else
            BundleTable.EnableOptimizations = true;
        #endif
    }
