    if (myCoordenates.Results != null && myCoordenates.Results.Length > 0)
    {
        string strLat = myCoordenates.Results[0].Geometry.Location.Lat.ToString();
    }
    else
    {
        // logic when myCoordenates.Results is null or myCoordenates.Results doesn't 
        // have any elements
    }
