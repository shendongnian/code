    public static byte[] ToBytes(object data)
        {
            using (var ms = new MemoryStream())
            {
                // create a binary formatter:
                var bnfmt = new BinaryFormatter();
                // serialize the data to the memory-steam;
                bnfmt.Serialize(ms, data);
                // return a byte[] representation of the binary data:
                return ms.GetBuffer();
            }
        }
        public static T FromBytes<T>(byte[] input)
        {
            using (var ms = new MemoryStream(input))
            {
                var bnfmt = new BinaryFormatter();
                // serialize the data to the memory-steam;
                var value = bnfmt.Deserialize(ms);
                return (T)value;
            }
        }
