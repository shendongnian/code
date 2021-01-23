    using (var ms = new MemoryStream())
    {
        // Important the true, so that the ms remains open!
        using (var bw = new BinaryWriter(ms, true))
        {
            // All the basic types are supported by various overlaods
            bw.Write(...); 
        }
        // Here you have your ms... If you want to reread it:
        ms.Position = 0;
        using (var br = new BinaryReader(ms, true))
        {
           // Reread it
        }
        // Or copy it to another stream, or do whatever you want
    }
