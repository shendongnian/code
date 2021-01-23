        public byte[] Serialize(Product product)
        {
            MemoryStream stream = new MemoryStream();
            XmlSerializer serializer = new XmlSerializer(typeof(Product)); 
            serializer.Serialize(stream, product);
            return stream.GetBuffer();
        }
