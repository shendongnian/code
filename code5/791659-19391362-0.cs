    using (FileStream fsStream = new FileStream("Bytes.data", FileMode.Create))
    using (BinaryWriter writer = new BinaryWriter(fsStream, Encoding.UTF8))
    {
        writer.Write("The");
        writer.Write(" strings");
        writer.Write(" I");
        writer.Write(" want");
        writer.Write(".");
        writer.Write(new byte[]
                     {
                         0xff,
                         0xfe
                     });
    }
