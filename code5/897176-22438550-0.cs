    foreach (AcadEntity ent in doc.ModelSpace)
    {
        var block = ent as AcadBlockReference;
        if (block == null || block.Name != block_Name)
            continue;
        foreach (AcadAttributeReference att in block.GetAttributes())
        {
            if (att.TagString != "Specified_String")
                continue;
            doc.ModelSpace.AddRaster(@"C:\Users\Public\Pictures\Sample Pictures\Jellyfish.jpg",
                                     att.InsertionPoint, 1, 0);
            break;
        }
    }
