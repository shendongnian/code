    public string MapFinder()
    {
        if ((Map.Width == 8 && Map.Height == 8))
        {
            return "DefaultMap";
        }
        return "Something Different";
    }
    public string MapTracker()
    {
            // call the method, include the "()"
            if(MapFinder() == "DefaultMap");
            {
                   return "Hello DefaultMap";
            }
            
            return "Hello StrangeMap";
    }               
