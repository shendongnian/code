    using (var fp = System.IO.File.Open(argv))
    {
        int b; // note: not a byte
    
        while ((b = fp.Readbyte()) >= 0)
        {
            byte ch = (byte) b;
            // use the byte
        }
    }
