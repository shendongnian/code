    byte[] inputArray;  // somehow you've obtained this
    using (var inputStream = new MemoryStream(inputStream))
    {
        using (var reader = new BinaryReader(inputStream))
        {
            float f1 = reader.ReadSingle();
            short s1 = reader.ReadInt16();
            int i1 = reader.ReadInt32();
        }
    }
