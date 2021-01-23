        public byte[] Serialize(Product product)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter =  new BinaryFormatter(); 
            formatter.Serialize(stream, product);
            return stream.GetBuffer();
        }
