    if (myCoordenates.Results != null && myCoordenates.Results.Length > 0)
    {
        if (myCoordenates.Results[0].Geometry != null
            && myCoordenates.Results[0].Geometry.Location != null)
        {
            string strLat = myCoordenates.Results[0].Geometry.Location.Lat.ToString();
        }
        else
        {
            // logic when myCoordenates.Results[0].Geometry is null or
            // myCoordenates.Results[0].Geometry.Location is null
        }
    }
    else
    {
        // logic when myCoordenates.Results is null or myCoordenates.Results doesn't 
        // have any elements
    }
