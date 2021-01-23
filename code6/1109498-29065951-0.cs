    public String MapFinder()
    {
        if ((Map.Width == 8 && Map.Height==8))
        {
            return "DefaultMap";
        }
        else
            return "Something Different";
    }
    
    public String MapTracker()
    {
        if( MapFinder() == "DefaultMap" ) // <- change
        {
            return "Hello DefaultMap";
        }
        else
        {
            return "Hello StrangeMap"; // <- change
        }
    }
