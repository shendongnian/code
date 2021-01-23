    void gmap_LoadCompleted(object sender, NavigationEventArgs e)
    {
        gmap.InvokeScript("initialize");
        // Add markers
        foreach (Marker myM in ListMarker)
        {
            Object[] CallArgs = new Object[3];
            CallArgs[0] = myM.Latitude.ToString();
            CallArgs[1] = myM.Longitude.ToString();
            CallArgs[2] = myM.ShortDescription;
            object dummy = gmap.InvokeScript("AddMarker", CallArgs);
        }
    }
