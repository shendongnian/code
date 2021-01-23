    ZipEntry zipentry1 = zip1["f1.dll"];
    ZipEntry zipentry2 = zip2["f2.dll"];
    
    if (zipentry1.Crc == zipentry2.Crc && zipentry1.UncompressedSize == zipentry2.UncompressedSize)
    {
        // uncompress
        zipentry1.Extract(ms1);
        zipentry2.Extract(ms2);
        byte[] b1 = new byte[ms1.Length];
        byte[] b2 = new byte[ms2.Length];
        ms1.Seek(0, SeekOrigin.Begin);
        ms2.Seek(0, SeekOrigin.Begin);
        ms1.BeginRead(b1, 0, (int) ms1.Length, null, null);
        ms2.BeginRead(b2, 0, (int) ms2.Length, null, null);
        // perform a byte comparison
        if (Enumerable.SequenceEqual(b1, b2)) // or a simple for loop
        {
            // files are the same
        }
        else
        {
            // files are different
        }
    }
    else
    {
        // files are different
    }
