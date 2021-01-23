    public unsafe struct StructType_2
    {
        long longVal_1;
        long longVal_2;
        long longVal;
        int intVal;
    }
    using (MemoryStream memory = new MemoryStream())
    {
        using (EndianBinaryWriter writer = new EndianBinaryWriter(EndianBitConverter.Big, stream))
        {
            writer.Write(longVal_1);
            writer.Write(longVal_2);
            writer.Write(longVal);
            writer.Write(intVal);
        }
        
        byte[] buffer = memory.ToArray();
        
        // Use buffer
    }
            
