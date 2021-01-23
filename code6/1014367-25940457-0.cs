    public static void GenericTester()
    {
        var source = GetSourceComponents();
        var destination = GetDestinationComponents();
        // Go through each source item
        foreach (var srcItem in source)
        {
            // And for each source, look through each destination item
            foreach (var dstItem in destination)
            {
                // See if the destination has the same Type as the source
                if (srcItem.Type == dstItem.Type)
                {
                    // source and destination are the same type, so examine file details
                    foreach (var srcDetail in srcItem.Details)
                    {
                        foreach (var dstDetail in dstItem.Details)
                        {
                            // See if destination detail has a filename that matches the source detail filename
                            if (srcDetail.Filename == dstDetail.Filename)
                            {
                                // Do some comparison between the source.ComponentDetail 
                                // and destination.ComponentDetail here:
                                // . . .
                                break;
                            }
                        }
                    }
                    break;
                }
            }
        }
    }
