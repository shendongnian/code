    public class XmlKeyValueList<T> : List<KeyValuePair<string, T>>, IXmlSerializable
    {
        // TODO: validate that the "Key" string using XmlConvert.VerifyName.
        // https://msdn.microsoft.com/en-us/library/System.Xml.Serialization.XmlSerializer%28v=vs.110%29.aspx
        // Any serializer created with the "XmlSerializer(typeof(T), rootAttribute)" must be cached
        // to avoid resource & memory leaks.
        class ValueSerializerCache
        {
            // By using a nested class with a static constructor, we defer generation of the XmlSerializer until it's actually required.
            static ValueSerializerCache()
            {
                var rootAttribute = new XmlRootAttribute();
                rootAttribute.ElementName = ValueTypeName;
                rootAttribute.Namespace = ValueTypeNamespace;
                serializer = new XmlSerializer(typeof(T), rootAttribute);
            }
            static readonly XmlSerializer serializer;
            internal static XmlSerializer Serializer { get { return serializer; } }
        }
        static string ValueTypeName { get { return typeof(T).DefaultXmlElementName(); } }
        static string ValueTypeNamespace { get { return typeof(T).DefaultXmlElementNamespace(); } }
        #region IXmlSerializable Members
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            var typeName = ValueTypeName;
            reader.ReadStartElement(); // Advance to the first sub element of the list element.
            while (reader.NodeType == XmlNodeType.Element)
            {
                var name = reader.Name;
                using (var subReader = reader.ReadSubtree())
                {
                    var doc = XDocument.Load(subReader);
                    if (doc != null && doc.Root != null)
                    {
                        doc.Root.Name = typeName;
                        using (var docReader = doc.CreateReader())
                        {
                            var obj = ValueSerializerCache.Serializer.Deserialize(docReader);
                            if (obj != null)
                            {
                                Add(new KeyValuePair<string, T>(name, (T)obj));
                            }
                        }
                    }
                }
                // Move past the XmlNodeType.Element
                if (reader.NodeType == XmlNodeType.EndElement)
                    reader.Read();
            }
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            foreach (var pair in this)
            {
                XDocument doc = new XDocument();
                using (var subWriter = doc.CreateWriter())
                {
                    // write xml into the writer
                    ValueSerializerCache.Serializer.Serialize(subWriter, pair.Value);
                }
                if (doc.Root == null)
                    continue;
                doc.Root.Name = pair.Key;
                // Remove redundant namespaces.
                foreach (var attr in doc.Root.Attributes().ToList())
                {
                    if (!attr.IsNamespaceDeclaration || string.IsNullOrEmpty(attr.Value))
                        continue;
                    if (writer.LookupPrefix(attr.Value) == attr.Name.LocalName)
                        attr.Remove();
                }
                doc.Root.WriteTo(writer);
            }
        }
        #endregion
    }
    public static class XmlSerializationHelper
    {
        public static string DefaultXmlElementName(this Type type)
        {
            var xmlType = type.GetCustomAttribute<XmlTypeAttribute>();
            if (xmlType != null && !string.IsNullOrEmpty(xmlType.TypeName))
                return xmlType.TypeName;
            var xmlRoot = type.GetCustomAttribute<XmlRootAttribute>();
            if (xmlRoot != null && !string.IsNullOrEmpty(xmlRoot.ElementName))
                return xmlRoot.ElementName;
            return type.Name;
        }
        public static string DefaultXmlElementNamespace(this Type type)
        {
            var xmlType = type.GetCustomAttribute<XmlTypeAttribute>();
            if (xmlType != null && !string.IsNullOrEmpty(xmlType.Namespace))
                return xmlType.TypeName;
            var xmlRoot = type.GetCustomAttribute<XmlRootAttribute>();
            if (xmlRoot != null && !string.IsNullOrEmpty(xmlRoot.Namespace))
                return xmlRoot.ElementName;
            return string.Empty;
        }
    }
