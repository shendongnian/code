    struct MyStruct
    {
        public long price;
        public char type;
        public char flag;
        public int amount;
        public long time;
    
        public byte[] OptionalBytes; // 50 bytes
        public int[] OptionalInts;   // 10 ints (i.e. 40 bytes)
    
        public static MyStruct Deserialize(byte[] data)
        {
            MyStruct result = new MyStruct();
            using (MemoryStream inputStream = new MemoryStream(data))
            using (BinaryReader reader = new BinaryReader(inputStream))
            {
                result.price = reader.ReadInt64();
                result.type = reader.ReadChar();
                result.flag = reader.ReadChar();
                result.amount = reader.ReadInt32();
                result.time = reader.ReadInt64();
                OptionalBytes = reader.ReadBytes(50);
                if (OptionalBytes == 50)
                {
                    try
                    {
                        result.OptionalInts = Enumerable.Range(0, 10)
                            .Select(i => reader.ReadInt32()).ToArray();
                    }
                    catch (EndOfStreamException)
                    {
                        // incomplete...ignore
                    }
                }
                else
                {
                    // incomplete...ignore
                    result.OptionalBytes = null;
                }
            }
            return result;
        }
    }
