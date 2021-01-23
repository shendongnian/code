     public static class XmlSerializerCache
    {
        private static object Locker = new object();
        private static Dictionary<string, XmlSerializer> SerializerCacheForUtils = new Dictionary<string, XmlSerializer>();
        public static XmlSerializer GetSerializer<T>()
        {
            return GetSerializer<T>(null);
        }
        public static XmlSerializer GetSerializer<T>(Type[] ExtraTypes)
        {
            return GetSerializer(typeof(T), ExtraTypes);
        }
        public static XmlSerializer GetSerializer(Type MainTypeForSerialization)
        {
            return GetSerializer(MainTypeForSerialization, null);
        }
        public static XmlSerializer GetSerializer(Type MainTypeForSerialization, Type[] ExtraTypes)
        {
            string Signature = MainTypeForSerialization.FullName;
            if (ExtraTypes != null)
            {
                foreach (Type Tp in ExtraTypes)
                    Signature += "-" + Tp.FullName;
            }
            XmlSerializer XmlEventSerializer;
            if (SerializerCacheForUtils.ContainsKey(Signature))
                XmlEventSerializer = SerializerCacheForUtils[Signature];
            else
            {
                if (ExtraTypes == null)
                    XmlEventSerializer = new XmlSerializer(MainTypeForSerialization);
                else
                    XmlEventSerializer = new XmlSerializer(MainTypeForSerialization, ExtraTypes);
                SerializerCacheForUtils.Add(Signature, XmlEventSerializer);
            }
            return XmlEventSerializer;
        }
        public static T Deserialize<T>(XDocument XmlData)
        {
            return Deserialize<T>(XmlData, null);
        }
        public static T Deserialize<T>(XDocument XmlData, Type[] ExtraTypes)
        {
            lock (Locker)
            {
                T Result = default(T);
                try
                {
                    XmlReader XmlReader = XmlData.Root.CreateReader();
                    XmlSerializer Ser = GetSerializer<T>(ExtraTypes);
                    Result = (T)Ser.Deserialize(XmlReader);
                    XmlReader.Dispose();
                    return Result;
                }
                catch (Exception Ex)
                {
                    throw new Exception("Could not deserialize to " + typeof(T).Name, Ex);
                }
            }
        }
        public static T Deserialize<T>(string XmlData)
        {
            return Deserialize<T>(XmlData, null);
        }
        public static T Deserialize<T>(string XmlData, Type[] ExtraTypes)
        {
            lock (Locker)
            {
                T Result = default(T);
                try
                {
                    using (MemoryStream Stream = new MemoryStream())
                    {
                        using (StreamWriter Writer = new StreamWriter(Stream))
                        {
                            Writer.Write(XmlData);
                            Writer.Flush();
                            Stream.Position = 0;
                            XmlSerializer Ser = GetSerializer<T>(ExtraTypes);
                            Result = (T)Ser.Deserialize(Stream);
                            Writer.Close();
                        }
                    }
                    return Result;
                }
                catch (Exception Ex)
                {
                    throw new Exception("Could not deserialize to " + typeof(T).Name, Ex);
                }
            }
        }
        public static XDocument Serialize<T>(T Object)
        {
            return Serialize<T>(Object, null);
        }
        public static XDocument Serialize<T>(T Object, Type[] ExtraTypes)
        {
            lock (Locker)
            {
                XDocument Xml = null;
                try
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                        ns.Add("", "");
                        using (StreamReader Reader = new StreamReader(stream))
                        {
                            XmlSerializer Serializer = GetSerializer<T>(ExtraTypes);
                            var settings = new XmlWriterSettings { Indent = true };
                            using (var w = XmlWriter.Create(stream, settings))
                            {
                                Serializer.Serialize(w, Object, ns);
                                w.Flush();
                                stream.Position = 0;
                            }
                            Xml = XDocument.Load(Reader, LoadOptions.None);
                            foreach (XElement Ele in Xml.Root.Descendants())
                            {
                                PropertyInfo PI = typeof(T).GetProperty(Ele.Name.LocalName);
                                if (PI != null && PI.IsDefined(typeof(XmlCommentAttribute), false))
                                    Xml.AddFirst(new XComment(PI.Name + ": " + PI.GetCustomAttributes(typeof(XmlCommentAttribute), false).Cast<XmlCommentAttribute>().Single().Value));
                            }
                            Reader.Close();
                        }
                    }
                    return Xml;
                }
                catch (Exception Ex)
                {
                    throw new Exception("Could not serialize from " + typeof(T).Name + " to xml string", Ex);
                }
            }
        }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class XmlCommentAttribute : Attribute
    {
        public string Value { get; set; }
    }
