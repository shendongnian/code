    class Test
    {
        public BinaryWriter Content { get; private set; }
        public Test(Stream stream)
        {
            Content = new BinaryWriter(stream);
        }
        public Test Write<T>(T data)
        {
         
            var method = typeof (BinaryWriter).GetMethod("Write", new[] {data.GetType()});
            if (method != null)
            {
                method.Invoke(Content, new object[] { data });
                
            }
            return this;
        }
    }
