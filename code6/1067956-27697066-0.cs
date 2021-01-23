        public byte[] SerializeVectors(Vector3DF[][] vectors)
        {
            var formatter = new BinaryFormatter();
            // note: if you are using a stream to write to the memory mapped file, 
            // you could pass it in instead of using this memory stream as an intermediary
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, vectors);
                return stream.ToArray();
            }
        }
        public Vector3DF[][] DeserializeVectors(byte[] vectorBuffer)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream(vectorBuffer, false))
            {
                return (Vector3DF[][])formatter.Deserialize(stream);
            }
        }</code>
