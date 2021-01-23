    using (var fp = System.IO.File.Open(argv))  // using provides exception-safe closing
    {
        int b; // note: not a byte
    
        while ((b = fp.Readbyte()) >= 0)
        {
            byte ch = (byte) b;
            // now use the byte in 'ch'
            create_frequency(ch);
        }
    }
