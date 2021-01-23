    public class Cache<T> where T : new()
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(T));
        private readonly string _file = string.Format("{0}.xml", typeof(T).Name);
        public void Serialize(T obj)
        {
            using (var writer = XmlWriter.Create(_file))
                _serializer.Serialize(writer, obj);
        }
        public T Deserialize()
        {
            if (!System.IO.File.Exists(File))
                return default(T);
            using (var reader = XmlReader.Create(_file))
                return (T) _serializer.Deserialize(reader);
        }
        public string File { get { return _file; } }
    }
