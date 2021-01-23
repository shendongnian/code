    public static void TileMapCapabilities(string title)
    {
        // This method call from another class fails because it can't access a non-static field in a static context
        TilePicker tp = new TilePicker();
        // initialize tp?
        tp.GetCapabilitiesInfo();
