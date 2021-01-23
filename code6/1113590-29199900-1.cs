    using (var yourStream = /* ... */)
    using (var br = new BinaryReader(yourStream))
    {
        using (var ms = new MemoryStream())
        {
            // Important the true, so that the ms remains open!
            using (var bw = new BinaryWriter(ms, Encoding.UTF8, true))
            {
                var readed = br.ReadInt32();
                bw.Write(readed); 
                // All the basic types are supported by various overlaods
            }
            // Here you have your ms... If you want to reread it:
            ms.Position = 0;
            using (var br2 = new BinaryReader(ms, Encoding.UTF8, true))
            {
                // Reread it
            }
            // Or copy it to another stream, or do whatever you want
        }
    }
