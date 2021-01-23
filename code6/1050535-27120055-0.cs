    public static string ToXml(object obj)
        {
            XmlSerializer s = new XmlSerializer(obj.GetType());
            using (StringWriterWithEncoding writer = new StringWriterWithEncoding(Encoding.UTF8))
            {
                s.Serialize(writer, obj);
                return writer.ToString();
            }
        }
        public static object FromXml<T>(this TextReader data)
        {
            XmlSerializer s = new XmlSerializer(typeof(T));
            object obj = s.Deserialize(data);
                return (T)obj;
        }
