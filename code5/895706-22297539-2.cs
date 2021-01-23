    string fileName = ...
    using (var fp = System.IO.File.OpenRead(fileName)) // using provides exception-safe closing
    {
        int b; // note: not a byte
    
        while ((b = fp.ReadByte()) >= 0)
        {
            byte ch = (byte) b;
            // now use the byte in 'ch'
            create_frequency(ch);
        }
    }
