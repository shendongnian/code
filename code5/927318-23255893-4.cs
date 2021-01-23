    namespace B
    {
        [Serializable]
        public class MySerializable
        {
            public MySerializable CopyMeBySerialization()
            {
                return DeepClone(this);
            }
            private static T DeepClone<T>(T obj)
            {
                using (var ms = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(ms, obj);
                    ms.Position = 0;
                    return (T)formatter.Deserialize(ms);
                }
            }
        }
    }
