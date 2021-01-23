    using(MemoryStream memory = new MemoryStream())
    using(BinaryWriter writer = new BinaryWriter(memory))
    {
        // write  into stream
        writer.Write((byte)0); // a byte
        writer.Write(0f);      // a float
        writer.Write("hello"); // a string
        return memory.ToArray(); // returns the underlying array
    }
