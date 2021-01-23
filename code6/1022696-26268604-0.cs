        class BSerializer<C, M> : ISerializer<B<C, M>>
            where C : IComparable<C>
            where M : IData<C>
        {
            public B<C, M> ReadFrom(System.IO.Stream stream)
            {
                byte[] value = CSharpTest.Net.Serialization.PrimitiveSerializer.Bytes.ReadFrom(stream);
                return Serializer.Deserialize<B<C, M>>(new MemoryStream(value));
            }
            public void WriteTo(B<C, M> value, System.IO.Stream stream)
            {
                using (var memory = new MemoryStream())
                {
                    Serializer.Serialize<B<C, M>>(memory, value);
                    CSharpTest.Net.Serialization.PrimitiveSerializer.Bytes.WriteTo(memory.ToArray(), stream);
                }
            }
        }
