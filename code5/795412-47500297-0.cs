        public object DeserializeObject()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Binder = new VersionDeserializer();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {
                    memoryStream.Write(_data, _ptr, count);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    return binaryFormatter.Deserialize(memoryStream);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        sealed class VersionDeserializer: SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                Type deserializeType = null;
                String thisAssembly = Assembly.GetExecutingAssembly().FullName;
                deserializeType = Type.GetType(String.Format("{0}, {1}",
                    typeName, thisAssembly));
                return deserializeType;
            }
        }
