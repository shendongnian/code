        public string SerializeBase64()
        {
            // Serialize to a base 64 string
            byte[] bytes;
            long length = 0;
            using (MemoryStream ws = new MemoryStream())
            {
                XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(ws);
                DataContractSerializer serializer = new DataContractSerializer(typeof(MyAbstractBase ), new List<Type>() { typeof(SomeOtherClass.MyDerivedClass) });
                serializer.WriteObject(writer, this);
                writer.Flush();
                length = ws.Length;
                // Note: https://msmvps.com/blogs/peterritchie/archive/2009/04/29/datacontractserializer-readobject-is-easily-confused.aspx
                // We need to trim nulls from the buffer produced by the serializer because it'll barf on them when it tries to deserialize.
                bytes = new byte[ws.Length];
                Array.Copy(ws.GetBuffer(), bytes, bytes.Length);
            }
            string encodedData = bytes.Length + ":" + Convert.ToBase64String(bytes, 0, bytes.Length, Base64FormattingOptions.None);
            return encodedData;
        }
