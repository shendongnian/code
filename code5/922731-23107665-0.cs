    interface ISerializableObject { }
    class PluginSerialization
    {
        private readonly IFormatter formatter;
        public PluginSerialization(IFormatter f)
        {
            formatter = f;
        }
        public void SerializeToStream(IEnumerable<ISerializableObject> components, Stream s)
        {
            foreach (var component in components)
            {
                using (var cStream = new MemoryStream())
                {
                    formatter.Serialize(cStream, component);
                    cStream.Flush();
                    // write to stream [length] [type as string] [object]
                    formatter.Serialize(s, cStream.Length);
                    formatter.Serialize(s, component.GetType().ToString());
                    cStream.WriteTo(s);
                }
            }
        }
        public List<ISerializableObject> DeserializeFromStream(Stream s, Func<string, bool> isKnownType )
        {
            var components = new List<ISerializableObject>();
            while (s.Position < s.Length - 1)
            {
                var length = (long)(formatter.Deserialize(s));
                var name = (string)(formatter.Deserialize(s));
                // skip unknown types
                if (!isKnownType(name))
                {
                    s.Position += length;
                    continue;
                }
                
                components.Add((ISerializableObject) (formatter.Deserialize(s)));                
            }
            return components;
        }
    }
