    if (myCoordenates.Results != null && myCoordenates.Results.Length > 3)
    {
        string strLat = myCoordenates.Results[3].Geometry.Location.Lat.ToString();
    }
    else
    {
        // logic when myCoordenates.Results is null or myCoordenates.Results has
        // less than four elements
    }
