    public String MapTracker()
    {
        String mapFinderResult;
        mapFinderResult = MapFinder();
        if( mapFinderResult == "DefaultMap" )
        {
            return "Hello DefaultMap";
        }
        else
        {
            return "Hello StrangeMap";
        }
    }
