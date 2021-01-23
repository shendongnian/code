    using (FileStream fsStream = new FileStream("Bytes.data", FileMode.Create))
    using (BinaryWriter writer = new BinaryWriter(fsStream, Encoding.UTF8))
    {
        // Writing the strings.
        writer.Write("The");
        writer.Write(" strings");
        writer.Write(" I");
        writer.Write(" want");
        writer.Write(".");
        // Writing your bytes afterwards.
        writer.Write(new byte[]
                     {
                         0xff,
                         0xfe
                     });
    }
