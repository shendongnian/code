    if (myCoordenates.Results != null && myCoordenates.Results.Length > 3)
    {
        if (myCoordenates.Results[3].Geometry != null
            && myCoordenates.Results[3].Geometry.Location != null)
        {
            string strLat = myCoordenates.Results[3].Geometry.Location.Lat.ToString();
        }
        else
        {
            // logic when myCoordenates.Results[3].Geometry is null or
            // myCoordenates.Results[3].Geometry.Location is null
        }
    }
    else
    {
        // logic when myCoordenates.Results is null or myCoordenates.Results has
        // less than four elements
    }
